using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Tomatoes
    {
        [BsonElement("viewer")]
        public Viewer Viewer { get; set; }
        [BsonElement("lastUpdated")]
        public DateTime LastUpdated { get; set; }
    }
}
