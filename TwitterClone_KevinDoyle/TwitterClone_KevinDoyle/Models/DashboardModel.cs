using System.Collections.Generic;

namespace TwitterClone_KevinDoyle.Models
{
    /// <summary>
    /// Contains the Tweets for the user and the user's name
    /// </summary>
    public class DashboardModel
    {
        public string UserName { get; set; }

        public string FullName { get; set; }

        public List<Tweet> Tweets { get; set; }

    }
}