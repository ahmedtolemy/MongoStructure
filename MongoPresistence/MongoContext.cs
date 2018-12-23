using System;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDomain;
using MongoPresistence.Mapping;

namespace MongoPresistence
{
   
    public class MongoContext
    {
        /// <summary>
        /// The default key MongoRepository will look for in the App.config or Web.config file.
        /// </summary>
         private readonly IConfiguration _configuration;
        private IMongoClient Client { get; set; }
        public IMongoDatabase Database { get; set; }
        private const string _databaseName = "Tasteef";
       // private static MongoContext _MongoContext=new MongoContext();

        public  MongoContext() {
            string connectionString = "mongodb://localhost:27017";
            Client = new MongoClient(connectionString);
            Database = Client.GetDatabase(_databaseName);
        }

      
        public static void InitMap()
        {
            new ApplicationMap().Map();
        }
        
    }
}
