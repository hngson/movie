using Infrastructure.DatabaseContext;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : MongoRepository<Movie>, IMovieRepository
    {
        public MovieRepository(IMongoDBContext context) : base(context)
        {
        }
    }
}
