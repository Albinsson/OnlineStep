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
        
        static readonly HttpClient Client;

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
            Client = new HttpClient {BaseAddress = new Uri("https://online-step.herokuapp.com/")};

        }

        public static async Task<List<Course>> GetCoursesAsync()
        {
            var productsRaw = await Client.GetStringAsync("courses/");

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

    }


}

