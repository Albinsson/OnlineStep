using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace OnlineStep.Models
{
    public class Mcq : IPage
    {
        /// <summary>
        /// This constructor is required for the JSON deserializer to be able
        /// to identify concrete classes to use when deserializing the interface properties.
        /// </summary>
        [JsonConstructor]
        public Mcq(string _id, string type, string title, string author)
        {
            this._id = _id;
            this.type = type;
            this.title = title;
            this.author = author;
        }
        public Content content { get; set; }
        public string _id { get; set; }
        public string type { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public class Content
        {
            public string question { get; set; }
            public List<string> answers { get; set; }
            public string correctAnswer { get; set; }
        }
    }

}
