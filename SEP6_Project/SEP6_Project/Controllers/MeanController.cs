using Microsoft.AspNetCore.Mvc;
using SEP6_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Controllers
{
    public class MeanController : Controller
    {
        DatabaseOperations db = new DatabaseOperations();
        public IActionResult MeanIndex()
        {
            return View();
        }

        public JsonResult loadMeanJFK()
        {
            TempModel tm = new TempModel();

            tm.mean_JFK = db.getDailyTempFromOrigin("JFK");
            return Json(tm);
        }

        public JsonResult meanTempAll()
        {
            TempModel tm = new TempModel();

            tm.mean_JFK = db.getDailyTempFromOrigin("JFK");
            tm.mean_EWR = db.getDailyTempFromOrigin("EWR");
            tm.mean_LGA = db.getDailyTempFromOrigin("LGA");
            return Json(tm);
        }
    }
}
