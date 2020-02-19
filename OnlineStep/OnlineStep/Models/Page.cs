using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStep.Models
{
    public class Page
    {
        public List<string> missingWords { get; set; }
        public string sentence { get; set; }
        public List<string> answers { get; set; }
        public string question { get; set; }
        public string correctAnswer { get; set; }

        public class RootObject
        {
            public string _id { get; set; }
            public string type { get; set; }
            public string title { get; set; }
            public string author { get; set; }
            public Page page { get; set; }
            public int __v { get; set; }
        }
    }
}
