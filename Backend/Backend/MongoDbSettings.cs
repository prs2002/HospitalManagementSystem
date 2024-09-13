namespace Backend
{
    public class MongoDbSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string UsersCollection { get; set; }
        public string AppointmentsCollection {  get; set; }
        public string ProvidersCollection { get; set; }

    }

}
