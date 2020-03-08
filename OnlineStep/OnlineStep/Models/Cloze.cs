using Newtonsoft.Json;
using System.Collections.Generic;
using Xamarin.Essentials;

namespace OnlineStep.Models
{
    public class Cloze : IPage
    {
        /// <summary>
        /// This constructor is required for the JSON deserializer to be able
        /// to identify concrete classes to use when deserializing the interface properties.
        /// </summary>
        [JsonConstructor]
        public Cloze(string _id, string type, string title, string author)
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
            public List<string> missingWords { get; set; }
            public string sentence { get; set; }

            public string image { get; set; }
        }
    }
}
