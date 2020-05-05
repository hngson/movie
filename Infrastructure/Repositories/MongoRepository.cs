using Infrastructure.DatabaseContext;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase Database;
        protected readonly IMongoCollection<TEntity> DbSet;

        protected MongoRepository(IMongoDBContext context)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        
        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
            return data.ToList();
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            var data = await DbSet.Find(FilterId(id)).FirstOrDefaultAsync();
            return data;
        }

        public virtual async Task<TEntity> AddAsync(TEntity obj)
        {
            await DbSet.InsertOneAsync(obj);
            return obj;
        }

        public virtual async Task<TEntity> UpdateAsync(string id, TEntity obj)
        {
            await DbSet.ReplaceOneAsync(FilterId(id), obj);
            return obj;
        }

        public virtual async Task<bool> RemoveAsync(string id)
        {
            var result = await DbSet.DeleteOneAsync(FilterId(id));
            return result.IsAcknowledged;
        }

        private static FilterDefinition<TEntity> FilterId(string key)
        {
            return Builders<TEntity>.Filter.Eq("_id", key);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        
    }
}
