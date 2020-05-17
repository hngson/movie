using MongoDB.Driver;
using MongoDB.Driver.Linq;

public static class MongoQueryableFullTextExtension
{
    public static IMongoQueryable<T> WhereText<T>(this IMongoQueryable<T> query, string search)
    {
        var filter = Builders<T>.Filter.Text(search);
        return query.Where(_ => filter.Inject());
    }
}