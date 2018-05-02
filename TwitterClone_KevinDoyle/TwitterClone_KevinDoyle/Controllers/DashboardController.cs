using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TwitterClone_KevinDoyle.Models;

namespace TwitterClone_KevinDoyle.Controllers
{
    /// <summary>
    /// Controller used to present the Dashboard's view
    /// </summary>
    public class DashboardController : Controller
    {
        /// <summary>
        /// Retrieves the user's information and tweets.
        /// </summary>
        /// <returns>The Dashboard's view</returns>
        public ActionResult Index()
        {
            return View(GetUserModel());
        }

        /// <summary>
        /// Creates a tweet entity and saves it to the database.
        /// </summary>
        /// <param name="tweetText">This is the text for the tweet.</param>
        /// <returns>Redirects back to the Dashboard's view when finished to show the new tweet.</returns>
        [HttpPost]
        public ActionResult AddTweet(string tweetText)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                var tweet = new Tweet();
                tweet.TweetText = tweetText;
                tweet.TweetTime = DateTime.Now;
                tweet.UserId = (int)Session["Id"];
                db.Tweets.Add(tweet);
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Dashboard");
        }

        /// <summary>
        /// Retrieves the user's from the Session
        /// </summary>
        /// <returns></returns>
        private DashboardModel GetUserModel()
        {
            var userId = (int)Session["Id"];

            var model = new DashboardModel();
            model.UserName = (string)Session["UserName"];
            model.FullName = (string)Session["FullName"];
            model.Tweets = GetTweets(userId);
            return model;
        }

        /// <summary>
        /// Retrieves a lit of tweets based on user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<Tweet> GetTweets(int userId)
        {
            using (TwitterCloneEntities db = new TwitterCloneEntities())
            {
                return db.Tweets.Where(x => x.UserId == userId).OrderBy(x => x.TweetTime).ToList();
            }
        }
    }
}