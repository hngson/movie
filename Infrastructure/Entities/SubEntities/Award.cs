using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Entities.SubEntities
{
    public class Award
    {
        [BsonElement("wins")]
        public double Wins { get; set; }
        [BsonElement("nominations")]
        public double Nominations { get; set; }
        [BsonElement("text")]
        public string Text { get; set; }
    }
}
