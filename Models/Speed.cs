using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_GPS.Speed_Interpreter_Webserver.Models
{
    public class Speed
    {
        public int SpeedMph { get; set; }

        public int SpeedKph { get; set; }

        public Speed(int _SpeedMph)
        {
            this.SpeedMph = _SpeedMph;
            this.SpeedKph = (int)(_SpeedMph * 1.609344);
        }
    }
}
