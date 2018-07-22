using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;

namespace EventStore
{
    public class EventStore
    {
        public EventStore(DatastoreProvider provider)
        {
            _provider = provider;
            _db = _provider.Init();
        }
        private readonly DatastoreProvider _provider;
        private DatastoreDb _db;
        public T Insert<T>(T entity) where T : class
        {
            CommitResponse resp;

            using (DatastoreTransaction transaction = _db.BeginTransaction())
            {
                var e = ToEntity(entity);
                transaction.Insert(e);
                resp = transaction.Commit();
            }
            return entity;
        }

        public async Task<T> InsertAsync<T>(T entity) where T : class
        {
            CommitResponse resp;

            using (DatastoreTransaction transaction = await _db.BeginTransactionAsync())
            {
                var e = ToEntity(entity);
                transaction.Insert(e);
                resp = await transaction.CommitAsync();
            }
            return entity;
        }

        public T Update<T>(T entity) where T : class
        {
            CommitResponse resp;

            using (DatastoreTransaction transaction = _db.BeginTransaction())
            {
                var e = ToEntity(entity);
                transaction.Update(e);
                resp = transaction.Commit();
            }
            return entity;
        }

        public async Task<T> UpdateAsync<T>(T entity) where T : class
        {
            //TODO: Refactor
            CommitResponse resp;

            using (DatastoreTransaction transaction = await _db.BeginTransactionAsync())
            {
                var e = ToEntity(entity);
                transaction.Update(e);
                resp = await transaction.CommitAsync();
            }

            return entity;
        }

        public T ReadFirstOrDefault<T>(Filter filter) where T : class
        {
            Query query = new Query(GetKind<T>())
            {
                Filter = filter
            };

            var result = _db.RunQuery(query);
            return result.Entities.Select(e => FromEntity<T>(e)).ToList().FirstOrDefault();
        }

        public async Task<T> ReadFirstOrDefaultAsync<T>(Filter filter) where T : class
        {
            Query query = new Query(GetKind<T>())
            {
                Filter = filter
            };

            var result = await _db.RunQueryAsync(query);
            return result.Entities.Select(e => FromEntity<T>(e)).ToList().FirstOrDefault();
        }

        public List<T> Read<T>(Filter filter) where T : class
        {
            Query query = new Query(GetKind<T>())
            {
                Filter = filter
            };

            var result = _db.RunQuery(query);
            return result.Entities.Select(e => FromEntity<T>(e)).ToList();
        }

        public async Task<List<T>> ReadAsync<T>(Filter filter) where T : class
        {
            Query query = new Query(GetKind<T>())
            {
                Filter = filter
            };

            var result = await _db.RunQueryAsync(query);
            return result.Entities.Select(e => FromEntity<T>(e)).ToList();
        }

        private Key ToKey<T>(string id) where T : class => new Key().WithElement(GetKind<T>(), id);

        private Entity ToEntity<T>(T entity) where T : class
        {
            var idProperty = entity.GetType().GetProperty("Id");

            var idValue = idProperty != null ? idProperty.GetValue(entity).ToString() : Guid.NewGuid().ToString();

            if (string.IsNullOrWhiteSpace(idValue))
            {
                idValue = Guid.NewGuid().ToString();
            }

            Entity e = new Entity
            {
                Key = _db.CreateKeyFactory(GetKind<T>()).CreateKey(idValue)
            };

            foreach (var item in entity.GetType().GetProperties())
            {
                var value = item.GetValue(entity);
                var notMappedAttribute = item.GetCustomAttribute<NotMappedAttribute>();

                if (value == null || notMappedAttribute != null)
                {
                    continue;
                }

                if (value.GetType() == typeof(string))
                {
                    e[item.Name] = (string)item.GetValue(entity, null);
                }
                else if (value.GetType() == typeof(Guid))
                {
                    e[item.Name] = ((Guid)item.GetValue(entity, null)).ToString();
                }
                else if (value.GetType() == typeof(DateTime))
                {
                    e[item.Name] = ((DateTime)item.GetValue(entity, null)).ToUniversalTime();
                }
                else if (value.GetType() == typeof(int))
                {
                    e[item.Name] = (int)item.GetValue(entity, null);
                }
                else if (value.GetType() == typeof(long))
                {
                    e[item.Name] = (long)item.GetValue(entity, null);
                }
                else if (value.GetType() == typeof(byte))
                {
                    e[item.Name] = (byte)item.GetValue(entity, null);
                }
                else if (value.GetType().GetTypeInfo().BaseType == typeof(Enum))
                {
                    e[item.Name] = (byte)item.GetValue(entity, null);
                }
                else if (value.GetType() == typeof(bool))
                {
                    e[item.Name] = (bool)item.GetValue(entity, null);
                }
                else if (value.GetType() == typeof(double))
                {
                    e[item.Name] = (double)item.GetValue(entity, null);
                }

                ExcludeFromIndexes(item, ref e);
            }

            return e;
        }

        private void ExcludeFromIndexes(PropertyInfo item, ref Entity entity)
        {
            var attribute = item.GetCustomAttribute<IndexedPropertyAttribute>();

            if (attribute == null)
                entity[item.Name].ExcludeFromIndexes = true;
        }

        private T FromEntity<T>(Entity entity) where T : class
        {
            if (entity == null)
                return null;

            T e = (T)Activator.CreateInstance(typeof(T));

            foreach (var item in typeof(T).GetProperties())
            {
                entity.Properties.TryGetValue(item.Name, out Value value);

                var attribute = item.GetCustomAttribute<NotMappedAttribute>();

                if (attribute != null)
                {
                    continue;
                }

                if (value == null || value.IsNull)
                {
                    item.SetValue(e, null);
                    continue;
                }

                switch (value.ValueTypeCase)
                {
                    case Value.ValueTypeOneofCase.BlobValue:
                    case Value.ValueTypeOneofCase.KeyValue:
                    case Value.ValueTypeOneofCase.None:
                    case Value.ValueTypeOneofCase.NullValue:
                    case Value.ValueTypeOneofCase.EntityValue:
                    case Value.ValueTypeOneofCase.GeoPointValue:
                        throw new NotImplementedException();

                    case Value.ValueTypeOneofCase.ArrayValue:
                        item.SetValue(e, value.ArrayValue);
                        break;

                    case Value.ValueTypeOneofCase.BooleanValue:
                        item.SetValue(e, value.BooleanValue);
                        break;

                    case Value.ValueTypeOneofCase.DoubleValue:
                        item.SetValue(e, value.DoubleValue);
                        break;

                    case Value.ValueTypeOneofCase.IntegerValue:
                        if (item.PropertyType == typeof(Enum))
                            item.SetValue(e, (byte)value.IntegerValue);
                        else if (item.PropertyType == typeof(Int64))
                            item.SetValue(e, Convert.ToInt64(value.IntegerValue));
                        else
                            item.SetValue(e, Convert.ToInt32(value.IntegerValue));
                        break;

                    case Value.ValueTypeOneofCase.StringValue:
                        if (item.PropertyType == typeof(Guid))
                            item.SetValue(e, new Guid(value.StringValue));
                        else
                            item.SetValue(e, value.StringValue);
                        break;

                    case Value.ValueTypeOneofCase.TimestampValue:
                        item.SetValue(e, value.TimestampValue.ToDateTime());
                        break;
                }
            }

            return e;
        }

        private static string GetKind<T>() where T : class
        {
            return typeof(T).Name.Replace("Entity", "");
        }
    }
}
