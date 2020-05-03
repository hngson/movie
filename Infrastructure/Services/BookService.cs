using Infrastructure.AppSettings;
using Infrastructure.Entity;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class BookService
    {
        private readonly IMongoCollection<Movie> _books;

        public BookService(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _books = database.GetCollection<Movie>("Books");
        }

        public List<Movie> Get() =>
            _books.Find(book => true).ToList();

        public Movie Get(string id) =>
            _books.Find<Movie>(book => book.Id == id).FirstOrDefault();

        public Movie Create(Movie book)
        {
            _books.InsertOne(book);
            return book;
        }

        public void Update(string id, Movie bookIn) =>
            _books.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(Movie bookIn) =>
            _books.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(string id) =>
            _books.DeleteOne(book => book.Id == id);
    }
}
