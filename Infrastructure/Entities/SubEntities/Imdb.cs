using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    [BsonIgnoreExtraElements]
    public class Imdb
    {
        [BsonElement("rating")]
        public double Rating { get; set; }
        [BsonElement("votes")]
        public double Votes { get; set; }
        [BsonElement("id")]
        public decimal Id { get; set; }
    }
}
