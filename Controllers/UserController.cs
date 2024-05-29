using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    public class UserController : Controller
    {
        // In-memory data structure to represent a set of User objects
        private static List<User> users = new List<User>();

        // GET: User
        public ActionResult Index()
        {
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                users.Add(user);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Search
        public ActionResult Search(string query)
        {
            var matchedUsers = users.Where(u => u.Name.Contains(query) || u.Email.Contains(query)).ToList();
            return View(matchedUsers);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                var existingUser = users.FirstOrDefault(u => u.Id == id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    existingUser.Email = user.Email;
                    // Update other properties as needed
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var user = users.FirstOrDefault(u => u.Id == id);
                if (user != null)
                {
                    users.Remove(user);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}