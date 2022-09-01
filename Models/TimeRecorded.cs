using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_GPS.Speed_Interpreter_Webserver.Models
{
    public class TimeRecorded
    {
        public string Date { get; set; }
        public string Time { get; set; }

        public TimeRecorded(string DateTime)
        {
            this.Date = DateTime.Substring(0, DateTime.LastIndexOf(" "));
            this.Time = DateTime.Substring(DateTime.LastIndexOf(" ")+1);
        }
    }
}
