using Infrastructure.DatabaseContext;
using Infrastructure.Entities;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : MongoRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IMongoDBContext context, IDistributedCache redisCache) : base(context, redisCache)
        {
        }

    }
}
