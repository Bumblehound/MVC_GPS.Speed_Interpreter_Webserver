using EntityFrameworkAccessLibrary.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_GPS.Speed_Interpreter_Webserver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using static EntityFrameworkAccessLibrary.Logic.DataProcessor;

namespace MVC_GPS.Speed_Interpreter_Webserver.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
  
        }

        public List<DateTime> GetDatesBetween()
        {
            DateTime today = DateTime.Today;
            int currentDayOfWeek = (int)today.DayOfWeek;
            DateTime sunday = today.AddDays(-currentDayOfWeek);
            DateTime monday = sunday.AddDays(1);
            // If we started on Sunday, we should actually have gone *back*
            // 6 days instead of forward 1...
            if (currentDayOfWeek == 0)
            {
                monday = monday.AddDays(-7);
            }
            var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
            return dates;
        }

        public IActionResult Index()
        {
            var dates = new List<DateTime>();
            //var maxSpeed = LoadMaxSpeed();
           // Debug.WriteLine($"Max Speed {maxSpeed}");

            List<GPS_TravelDataModel> _travelData = ReturnSpeedData();//Main List
            //int maxSpeed = _travelData
            //    .Where(r => r.Speed != null )
            //    .Max(r => r.Speed.SpeedMph);

            Debug.WriteLine(GetDatesBetween().Count());
            List<GPS_TravelDataModel> _speedingInstance = _travelData
                .Where(o => o.Speed.SpeedMph >= 55)//&& GetDatesBetween().Contains(DateTime.Parse(o.TimeRecorded.Date))
                .OrderByDescending(o => o.Speed.SpeedMph)
                .Take(3)
                .Select(o => new GPS_TravelDataModel
                {
                    Id = o.Id,
                    TimeRecorded = o.TimeRecorded,
                    Speed = new Speed(o.Speed.SpeedMph),
                    Longitude = o.Longitude,
                    Latitude = o.Latitude
                }).ToList();
            int max = _travelData.Max(i => i.Speed.SpeedMph);
            var _maxSpeed = _travelData.First(x => x.Speed.SpeedMph == max);

            Debug.WriteLine(max);
            Debug.WriteLine(_maxSpeed.TimeRecorded.Date);

            dynamic model = new ExpandoObject();
            model.speedingInstance = _speedingInstance;
            model.travelData = _travelData;
            model.maxSpeed = _maxSpeed;
            ViewBag.DocumentTitle = "Ollie is a bad Driver";
            ViewBag.SpeedHeader = "Oliver has been caught Speeding!";
            //ViewBag.SpeedBody = $"He was driving at a speed of {maxSpeed} mph, please click the button below for more infomation";
            //ViewBag.MaxSpeed = maxSpeed;
            ViewBag.StartOfWeek = "NO";
            ViewBag.EndOfWeek = "NO";
            return View(model);
        }
        public List<GPS_TravelDataModel> ReturnSpeedData()
        {
            var allJourneys = LoadAllData(); //DataProcessor Method
            var journey = LoadRecentJourney(DateTime.Now.Date);
            List<GPS_TravelDataModel> travelData = new List<GPS_TravelDataModel>();
            foreach (var row in allJourneys)
            {
                travelData.Add(new GPS_TravelDataModel
                {
                    Id = row.Id,
                    TimeRecorded = new TimeRecorded(row.DateTime),
                    Speed = new Speed(row.Speed),
                    Longitude = row.Longitude,
                    Latitude = row.Latitude
                });
            }
            return travelData;
        }
        //Utilize to update Database
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult DataUpload(GPS_Speed_Model model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //UploadData() Method
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        
        public IActionResult Privacy()
        {
            var dates = new List<DateTime>();
            
            List<GPS_TravelDataModel> _travelData = ReturnSpeedData();//Main List
            int maxSpeed = _travelData
                .Where(r => r.Speed != null)
                .Max(r => r.Speed.SpeedMph);

   
            Debug.WriteLine(GetDatesBetween().Count());
            List<GPS_TravelDataModel> _speedingInstance = _travelData
                .Where(o => o.Speed.SpeedMph >= 55)
                .OrderByDescending(o => o.Speed.SpeedMph)
                .Take(3)
                .Select(o => new GPS_TravelDataModel
                {
                    Id = o.Id,
                    TimeRecorded = o.TimeRecorded,
                    Speed = new Speed(o.Speed.SpeedMph),
                    Longitude = o.Longitude,
                    Latitude = o.Latitude
                }).ToList();
            Debug.WriteLine(_speedingInstance.Count());
            //data.ForEach(delegate (GPS_TravelDataModel obj)
            //{
            //    Debug.Write(obj.Id + '\n');
            //});
            dynamic model = new ExpandoObject();
            model.speedingInstance = _speedingInstance;
            model.travelData = _travelData;
            ViewBag.DocumentTitle = "Ollie is a bad Driver";
            ViewBag.SpeedHeader = "Oliver has been caught Speeding!";
            ViewBag.SpeedBody = $"He was driving at a speed of {maxSpeed} mph, please click the button below for more infomation";
            ViewBag.MaxSpeed = maxSpeed;
            ViewBag.StartOfWeek = "NO";
            ViewBag.EndOfWeek = "NO";
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
