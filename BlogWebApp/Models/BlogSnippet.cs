using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogWebApp.Models
{
    public class BlogSnippet
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PostedOn { get; set; }
        public string Abstract { get; set; } = string.Empty;
        public string Url { get; set; } = "#";
        public ICollection<string> Keywords { get; set; } = new List<string>();
        public ICollection<string> Categories { get; set; } = new List<string>();
    }
}
