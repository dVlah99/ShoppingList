using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;
using test.Models;

namespace test.Models
{
    public class GList
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string? Id { get; set; }

        public string? StoreName { get; set; }

        [BsonElement("items")]
        [JsonPropertyName("items")]
        public List<Item>? Items { get; set; } = null!;
    }
}
