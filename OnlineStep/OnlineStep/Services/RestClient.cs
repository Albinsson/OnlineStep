using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OnlineStep.Models;

namespace OnlineStep.Services
{
    class RestClient
    {
        
        private const string WISHLIST_FILE = "wishlist.json";
        static HttpClient client;

        public static List<Course> WishList
        {
            get;
            set;
        }

        public RestClient()
        {

        }

        static RestClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://online-step.herokuapp.com/");

        }

        public static async List<Course> GetCoursesAsync()
        {
            var productsRaw = await client.GetStringAsync("courses/");

            var serializer = new JsonSerializer();
            using (var tReader = new StringReader(productsRaw))
            {
                using (var jReader = new JsonTextReader(tReader))
                {
                    var courses = serializer.Deserialize<List<Course>>(
                        jReader);

                    return courses;
                }
            }
        }

        public static async Task SaveWishList()
        {
            if (WishList != null && WishList.Count > 0)
            {
                //Save Products to Wish List
            }
        }

        public static async Task LoadWishList()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }


}

