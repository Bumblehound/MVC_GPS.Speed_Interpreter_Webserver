using System;
using System.Collections.Generic;
using System.Text;

namespace MVC_GPS.Speed_Interpreter_Webserver.Models
{
    public class GPS_TravelDataModel
    {
        public string Id { get; set; }
        public TimeRecorded TimeRecorded { get; set; }
        public Speed Speed { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }

        public GPS_TravelDataModel()
        {

        }
    }
}
