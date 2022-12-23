using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace lb3.Models
{
    public class Conversation
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public int AbonentId { get; set; }
        public int CityId { get; set; }
        public DateTime DateConversation { get; set; }
        public int Duration { get; set; }
        public Abonent? Abonent { get; set; }
        public City? City { get; set; }
    }
}
