using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Globalization;

namespace LiveMessenger
{
    public class MessageModel
    {
        public string User { get; set; }

        public string Message { get; set; }

        public string Room { get; set; }

        public DateTime Date { get; set; }

        public MessageModel(string UserIN, string MessageIN, string RoomIN){
            User = UserIN;
            Message = MessageIN;
            Room = RoomIN;
            Date = DateTime.Now;
            System.Console.WriteLine(User + " " + Message + " " + Room + " " + Date);
        }

        public void SaveMessage()
        {
            var collection = connectToDB.db.GetCollection<MessageModel>("Messages");
            collection.InsertOne(this);
        }
    }
}