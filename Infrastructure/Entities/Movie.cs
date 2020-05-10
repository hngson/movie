using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Collections.Generic;
using System;
using Infrastructure.Entities.SubEntities;

namespace Infrastructure.Entities
{
    public class Movie: BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("plot")]
        public string Plot { get; set; }
        [BsonElement("genres")]
        public List<string> Genres { get; set; }
        [BsonElement("runtime")]
        public decimal Runtime { get; set; }
        [BsonElement("cast")]
        public List<string> Cast { get; set; }
        [BsonElement("num_mflix_comments")]
        public decimal NumMflixComments { get; set; }
        [BsonElement("title")]
        public string Title { get; set; }
        [BsonElement("fullplot")]
        public string FullPlot { get; set; }
        [BsonElement("countries")]
        public List<string> Countries { get; set; }
        [BsonElement("released")]
        public DateTime Released { get; set; }
        [BsonElement("directors")]
        public List<string> Directors { get; set; }
        [BsonElement("rated")]
        public string Rated { get; set; }
        [BsonElement("awards")]
        public Award Awards { get; set; }
        [BsonElement("lastupdated")]
        public string Lastupdated { get; set; }
        [BsonElement("year")]
        public decimal Year { get; set; }
        [BsonElement("imdb")]
        public Imdb Imdb { get; set; }
        [BsonElement("type")]
        public string Type { get; set; }
        [BsonElement("tomatoes")]
        public Tomatoes Tomatoes { get; set; }
    }
}