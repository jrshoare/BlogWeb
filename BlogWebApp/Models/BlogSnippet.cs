using System;

namespace BlogWebApp.Models
{
    public class BlogSnippet
    {
        public string Title { get; set; } = string.Empty;
        public DateTime PostedOn { get; set; } = DateTime.MaxValue;
        public string Abstract { get; set; } = string.Empty;
        public string Url { get; set; } = "#";
    }
}
