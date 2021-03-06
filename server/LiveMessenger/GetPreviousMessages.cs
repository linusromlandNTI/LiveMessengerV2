using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LiveMessenger
{
    public class GetPreviousMessages
    {   
        //Retrieves all Messages from MongoDB Collection Messages, but only the ones that matches roomID.
        public static List<BsonDocument> RetrievePreviousMessages(string roomID)
        {
            var collection = ConnectToDB.db.GetCollection<BsonDocument>("Messages");
            var filter = Builders<BsonDocument>.Filter.Eq("Room", roomID);
            return collection.Find(filter).ToList();
        }
    }
}
