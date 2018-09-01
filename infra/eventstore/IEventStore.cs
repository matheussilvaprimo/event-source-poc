using System.Collections.Generic;
using System.Threading.Tasks;
using Google.Cloud.Datastore.V1;

namespace EventStore
{
    public interface IEventStore
    {
        T Insert<T>(T e) where T : class;
        Task<T> InsertAsync<T>(T e) where T : class;
        T Update<T>(T e) where T : class;
        Task<T> UpdateAsync<T>(T e) where T : class;
        T ReadFirstOrDefault<T>(Filter filter) where T : class;
        Task<T> ReadFirstOrDefaultAsync<T>(Filter filter) where T : class;
        List<T> Read<T>(Filter filter) where T : class;
        Task<List<T>> ReadAsync<T>(Filter filter) where T : class;
    }
}
