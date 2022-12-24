using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UrlShortener.Source.Models;

[BsonIgnoreExtraElements]
public class UrlModel
{
    public string LongUrl { get; set; }
    public string ShortUrl { get; set; }
    public string ShortId { get; set; }
}