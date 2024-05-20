using CRUD_application_2.Models;
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
        public static System.Collections.Generic.List<User> userlist = new System.Collections.Generic.List<User>();

        // GET: User
        public ActionResult Index()
        {
            // Return the list of users to the view
            return View(userlist);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            // Find the user with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);
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
            // Return an empty view to create a user
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            // Add the new user to the list and redirect to the index view
            userlist.Add(user);
            return RedirectToAction("Index");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            // Find the user with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            // Return the user to the view
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User user)
        {
            // Find the user with the given id
            var existingUser = userlist.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return HttpNotFound();
            }
            // Update the user's information
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            // Redirect to the index view
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            // Find the user with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);
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
            // Find the user with the given id
            var user = userlist.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            // Remove the user from the list and redirect to the index view
            userlist.Remove(user);
            return RedirectToAction("Index");
        }
    }
}
