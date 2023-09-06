using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace test.Models
{
    public enum Measurement
    {
        KG,
        G,
        L,
    }

    public class Item
    {

        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public string? Measurement { get; set; }
        public string? Description { get; set; } = string.Empty;
        public bool? Check { get; set; }
    }
}