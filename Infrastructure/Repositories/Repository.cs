using Infrastructure.Common;
using Infrastructure.DatabaseContext;
using Microsoft.Extensions.Caching.Distributed;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public abstract class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoDatabase Database;
        protected readonly IMongoCollection<TEntity> DbSet;
        protected readonly IDistributedCache _redisCache;

        protected MongoRepository(IMongoDBContext context, IDistributedCache redisCache)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<TEntity>(typeof(TEntity).Name);
            _redisCache = redisCache;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var cacheKey = typeof(TEntity).Name;
            var cachedData = _redisCache.GetString(cacheKey);
            if (string.IsNullOrEmpty(cachedData))
            {
                var data = await DbSet.FindAsync(Builders<TEntity>.Filter.Empty);
                await _redisCache.SetStringAsync(cacheKey, JsonConvert.SerializeObject(data.ToList<TEntity>()));
                cachedData = _redisCache.GetString(cacheKey);

                return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(cachedData);
            }

            return JsonConvert.DeserializeObject<IEnumerable<TEntity>>(cachedData);

        }
        public virtual async Task<IEnumerable<TEntity>> GetPagnedListAsync(
            string keyword, string orderBy, OrderType orderType, int page, int pageSize
            )
        {
            var skipNumber = pageSize * (page - 1);
            var data = await DbSet.Find(Builders<TEntity>.Filter.Empty)
                .Skip(skipNumber)
                .Limit(pageSize).ToListAsync();

            return data;
        }

        public virtual async Task<TEntity> GetByIdAsync(string id)
        {
            var cacheKey = typeof(TEntity).Name + "_" + id;
            var cachedData = _redisCache.GetString(cacheKey);
            if (string.IsNullOrEmpty(cachedData))
            {
                var data = await DbSet.Find(FilterId(id)).FirstOrDefaultAsync();
                _redisCache.SetString(cacheKey, JsonConvert.SerializeObject(data));
                cachedData = _redisCache.GetString(cacheKey);
                return JsonConvert.DeserializeObject<TEntity>(cachedData);
            }
            return JsonConvert.DeserializeObject<TEntity>(cachedData);
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

        private static FilterDefinition<TEntity> FilterId(string id)
        {
            return Builders<TEntity>.Filter.Eq("_id", new ObjectId(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
