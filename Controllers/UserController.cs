using CRUD_application_2.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CRUD_application_2.Controllers
{
    /*
        public class UserController : Controller
        {
            public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();
            // GET: User
            public ActionResult Index()
            {
                // Implement the Index method here

            }

            // GET: User/Details/5
            public ActionResult Details(int id)
            {
                // Implement the details method here
            }

            // GET: User/Create
            public ActionResult Create()
            {
                //Implement the Create method here
            }

            // POST: User/Create
            [HttpPost]
            public ActionResult Create(User user)
            {
                // Implement the Create method (POST) here
            }

            // GET: User/Edit/5
            public ActionResult Edit(int id)
            {
                // This method is responsible for displaying the view to edit an existing user with the specified ID.
                // It retrieves the user from the userlist based on the provided ID and passes it to the Edit view.
            }

            // POST: User/Edit/5
            [HttpPost]
            public ActionResult Edit(int id, User user)
            {
                // This method is responsible for handling the HTTP POST request to update an existing user with the specified ID.
                // It receives user input from the form submission and updates the corresponding user's information in the userlist.
                // If successful, it redirects to the Index action to display the updated list of users.
                // If no user is found with the provided ID, it returns a HttpNotFoundResult.
                // If an error occurs during the process, it returns the Edit view to display any validation errors.
            }

            // GET: User/Delete/5
            public ActionResult Delete(int id)
            {
                // Implement the Delete method here
            }

            // POST: User/Delete/5
            [HttpPost]
            public ActionResult Delete(int id, FormCollection collection)
            {
                // Implement the Delete method (POST) here
            }
        }
    */
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
            if (user == null)
            {
                return HttpNotFound();
            }
            // Return the user to the view
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
            if (user == null)
            {
                return HttpNotFound();
            }
            // Return the user to the view
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