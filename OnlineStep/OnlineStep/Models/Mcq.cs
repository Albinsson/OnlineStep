using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStep.Models
{
    public class Mcq
    {
        public string Question { get; set; }
        public List<string> Answers { get; set; }
        public string CorrectAnswer { get; set; }
    }
}
