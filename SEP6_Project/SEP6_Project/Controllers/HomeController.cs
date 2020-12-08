using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SEP6_Project.Models;
using System.Data.SqlClient;

namespace SEP6_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            DataModel dm = new DataModel();
            DatabaseOperations db = new DatabaseOperations();
            dm.flights = db.TotalFlightsMonth();
            return View(dm);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [System.Web.Mvc.HttpGet]
        public JsonResult SelectOrigin()
        {
            List<int> flights = new List<int>();
            DataModel dm = new DataModel();
            DatabaseOperations db = new DatabaseOperations();
            dm.flightsJFK = db.FlightsOriginJFK();
            dm.flightsEWR = db.FlightsOriginEWR();
            dm.flightsLGA = db.FlightsOriginLGA();
            return Json(dm);
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
