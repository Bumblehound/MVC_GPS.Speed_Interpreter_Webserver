using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_GPS.Speed_Interpreter_Webserver.Models
{
    public class GPS_LocationModel
    {
        public string Id { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
    }
}
