﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Infrastructure.Entities
{
    public class Anime: BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string EspisodeTitle { get; set; }
        public string SecondEspisodeTitle { get; set; }
    }
}
