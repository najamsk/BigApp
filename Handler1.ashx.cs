using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace BigApp
{
    /// <summary>
    /// Summary description for Handler1
    /// </summary>
    public class Handler1 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            // This will be the case whether there's a cache hit or not.
            context.Response.ContentType = "application/json";
            string id = context.Request.QueryString["id"];
            id = string.IsNullOrEmpty(context.Request.QueryString["id"]) ? "Encosia" : id;
            // Check to see if the twitter status is already cached,
            //   then retrieve and return the cached value if so.
            if (context.Cache["tweets"] != null)
            {
                string cachedTweets = context.Cache["tweets"].ToString();

                context.Response.Write(cachedTweets);

                // We're done here.
                return;
            }

            WebClient twitter = new WebClient();
           
            // Move along; nothing to see here. The concatenation is just
            //  to avoid horizontal scrolling within the meager 492
            //  pixels I have to work with here.
            string url = "http://api.twitter.com/1/statuses/" +
                         "user_timeline.json?id=" + id;

            string tweets = twitter.DownloadString(url);

            // This monstrosity essentially just caches the WebClient result
            //  with a maximum lifetime of 5 minutes from now.
            // If you don't care about the expiration, this can be a simple
            //  context.Cache["tweets"] = tweets; instead.
            context.Cache.Add("tweets", tweets,
              null, DateTime.Now.AddMinutes(5),
              System.Web.Caching.Cache.NoSlidingExpiration,
              System.Web.Caching.CacheItemPriority.Normal,
              null);

            context.Response.Write(tweets);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}