using System;

namespace BlogWebApp
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method, AllowMultiple = false)]
    public class XClacksOverheadAttribute : HeaderAttribute
    {
        public XClacksOverheadAttribute()
        {
            Name = "X-Clacks-Overhead";
            Value = "GNU Terry Pratchett";
        }
    }
}
