using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lb3.Models
{
    public class Abonent
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SurName { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
