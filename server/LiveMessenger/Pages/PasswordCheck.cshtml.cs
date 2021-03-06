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
    public class PasswordCheckModel : PageModel
    {
        public BsonDocument room { get; set; }

        public IActionResult OnGet()
        {
            if (!CheckCookie.checkUsername(Request)) return Redirect("ChangeUsername");
            String id = Request.Query["id"];
            if (!CheckRoom.byID(id)) return Redirect("/");
            room = GetRoom.RetrieveOneRoom(id);
            return null;
        }
        public IActionResult OnPost(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
            {
                password = password.Length > 69 ? password.Substring(0, 69) : password; //Cuts the Password at 69
                String id = Request.Query["id"];
                System.Console.WriteLine(password);
                if (CheckPassword.isCorrect(password, id))
                {
                    Response.Cookies.Append(id, password);
                    return Redirect($"/Chat?id={id}");
                }
            }
            return Redirect("/");
        }
    }
}
