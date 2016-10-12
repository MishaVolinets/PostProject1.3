using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using PostProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PostProject.Controllers
{
    public class UserController : Controller
    {

        ApplicationDbContext usersDb = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UserPage(string UserId)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.UserId = UserId;
                return View();
            }
            return View("Error");
        }
        public string GetUserById(string UserId)
        {

            var user = usersDb.Users.Find(UserId);
            var custumedUser = new {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                NativeTown = user.NativeTown,
                Hobby = user.Hobby,
                Image = user.srcPhoto
                };
                 var jsonUser = JsonConvert.SerializeObject(custumedUser);
                 return jsonUser;
            
        }
        public string GetAllUsers()
        {
            string id = User.Identity.GetUserId();
            var currentUser = usersDb.Users.Find(id);
            List<ApplicationUser> AllUsers = usersDb.Users.ToList();
            AllUsers.Remove(currentUser);

            var jsonAllUsers = JsonConvert.SerializeObject(AllUsers);
            return jsonAllUsers;
        }
        public void SaveEditedPost(ApplicationUser user)
        {
            var oldUser = usersDb.Users.Find(user.Id);
            oldUser.Age = user.Age;
            oldUser.NativeTown = user.NativeTown;
            oldUser.Hobby = user.Hobby;
            usersDb.SaveChanges();
        }
        public string GetCurrentUserId()
        {
            return User.Identity.GetUserId();
        }
        public ActionResult AllUsers()
        {
            return View();
        }
    }
}