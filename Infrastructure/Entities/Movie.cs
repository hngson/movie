using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Infrastructure.Entities
{
    public class Movie: BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public decimal Year { get; set; }
        [BsonElement]
        public string PosterUrl { get; set; }
        [BsonElement]
        public string ShortPlot { get; set; }
        [BsonElement]
        public string FullPlot { get; set; }
        [BsonElement]
        public string Directors { get; set; }
        [BsonElement]
        public string Country { get; set; }
        [BsonElement]
    }
}