using Google.Cloud.Datastore.V1;

namespace EventStore
{
    public class DatastoreProvider
    {
        private readonly string _projectID;
        private readonly string _namespaceID;

        public DatastoreProvider(string projectID, string namespaceID)
        {
            _projectID = projectID;
            _namespaceID = namespaceID;
        }

        public DatastoreDb Init()
        {
            return DatastoreDb.Create(_projectID, _namespaceID);
        }
    }
}
