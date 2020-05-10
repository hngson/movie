using Infrastructure.AppSettings;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DatabaseContext
{
    public class MongoDBContext : IMongoDBContext
    {
        public MongoDBContext(IDatabaseSettings connectionSetting)
        {
            var client = new MongoClient(connectionSetting.ConnectionString);
            Database = client.GetDatabase(connectionSetting.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}
