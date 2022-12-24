using MongoDB.Driver;
using UrlShortener.Source.Models;
using UrlShortener.Source.Utils.Data;

namespace UrlShortener.Source.Services;

public class DatabaseService
{
    private IMongoCollection<UrlModel>? Collection { get; set; }

    public DatabaseService()
    {
        var settings = MongoClientSettings.FromConnectionString(DbConfig.ConnectionUrl);
        var client = new MongoClient(settings);

        var database = client.GetDatabase(DbConfig.DatabaseName);
        Collection = database.GetCollection<UrlModel>("details");
    }

    public async Task<List<UrlModel>> GetAllAsync() =>
        await Collection.Find(_ => true).ToListAsync();

    public async Task<UrlModel?> GetById(string id) =>
        await Collection.Find(u => u.ShortId == id).FirstOrDefaultAsync();

    public async Task CreateUrl(UrlModel url)
    {
        if (Collection is null)
            return;
        
        await Collection.InsertOneAsync(url);
    }
}