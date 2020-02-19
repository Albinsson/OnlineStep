using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStep.Models
{
    public class Cloze
    {
        public string Sentence { get; set; }
        public List<string> MissingWords { get; set; }
    }
}
