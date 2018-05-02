using System.Linq;
using System.Web.Mvc;
using TwitterClone_KevinDoyle.Models;

namespace TwitterClone_KevinDoyle.Controllers
{
    public class LogInController : Controller
    {
        /// <summary>
        /// Sends out the Login view
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Checks to make sure that the user credentials are valid.
        /// If valid, a session is created containing the id, UserName, and FullName of the user
        /// </summary>
        /// <param name="userModel">The user's model containing the credentials </param>
        /// <returns>If valid, sends the info to the Dashboard controller, else sends the info back to the Login view</returns>
        [HttpPost]
        public ActionResult Authorize(User userModel)
        {
            if (string.IsNullOrWhiteSpace(userModel.UserName) || string.IsNullOrWhiteSpace(userModel.Password))
            {
                return View("Index", userModel);
            }

            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                var userDetails = db.Users.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    return View("Index", userModel);
                }

                Session["Id"] = userDetails.UserId;
                Session["UserName"] = userDetails.UserName;
                Session["FullName"] = string.Format($"{userDetails.FirstName} {userDetails.LastName}");
                return RedirectToAction("Index", "Dashboard");
            }
        }

        /// <summary>
        /// Abandons the session
        /// </summary>
        /// <returns>Redirects user back to Login view</returns>
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "LogIn");
        }
    }
}