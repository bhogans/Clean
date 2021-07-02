using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CleanRazorUI.Models
{
    [Serializable]
    public class Address
    {
        public Address()
        {
            this.Id = ObjectId.GenerateNewId().ToString();
            //Location = new Location();
        }

        [BsonId]
        public Object Id { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        //[BsonElement("CC")]
        public string Country { get; set; }
        public string Notes { get; set; }
        public Location Location { get; set; }

        public string ClientId { get; set; }
    }
}
