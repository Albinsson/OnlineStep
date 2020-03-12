using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStep.Models
{
    public class User
    {
        public string Xp { get; set; }
        public Dictionary<string, double> ChapterProgress { get; set; }
    }
}
