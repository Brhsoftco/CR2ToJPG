using System;

namespace structure
{
    public class AppContext
    {
        public DateTime TimeCreated = DateTime.Now;
        public string AppVersion = "";
        public string UserName = Environment.UserName;
    }
}