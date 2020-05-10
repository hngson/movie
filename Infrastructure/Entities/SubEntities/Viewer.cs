using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities
{
    public class Viewer
    {
        [BsonElement("rating")]
        public double Rating { get; set; }
        [BsonElement("numReviews")]
        public double NumReviews { get; set; }
        [BsonElement("meter")]
        public double Meter { get; set; }
    }
}
