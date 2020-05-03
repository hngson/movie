

using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infrastructure.Entity
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }
}