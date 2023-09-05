using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace test.Models
{

    public class Item
    {

        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public bool? Check { get; set; }  
    }
}