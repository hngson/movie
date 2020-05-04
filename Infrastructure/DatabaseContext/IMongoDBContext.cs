using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DatabaseContext
{
    public interface IMongoDBContext
    {
        IMongoDatabase Database { get; }
    }
}
