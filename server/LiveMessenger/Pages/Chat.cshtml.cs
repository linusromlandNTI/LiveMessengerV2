using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LiveMessenger;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace LiveMessenger.Pages
{
    public class ChatModel : PageModel
    {
        public List<BsonDocument> previousMessages { get; set; }

        public BsonDocument room { get; set; }
        public IActionResult OnGet()
        {
            if (!CheckCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            if (!CheckRoom.byID(id)) return Redirect("/");
            room = GetRoom.RetrieveOneRoom(id);
            if (room.GetElement("Private").Value == true && !CheckPassword.isCorrect(Request.Cookies[id], id)) return Redirect($"/PasswordCheck?id={id}");
            previousMessages = GetPreviousMessages.RetrievePreviousMessages(id);
            return null;
        }
        public void OnPost()
        {
        }
    }
}
