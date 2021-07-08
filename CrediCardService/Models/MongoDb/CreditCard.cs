using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreditCardService.Models.MongoDb
{
    public class CreditCard
    {
        [BsonId]
        //object Id
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public string ValidMounth { get; set; }
        public string ValidYear { get; set; }
        public string Cvv { get; set; }

        public int Balance { get; set; }
    }
}
