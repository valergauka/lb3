using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lb3.Models
{
    public class City
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public int Tariff { get; set; }
    }
}
