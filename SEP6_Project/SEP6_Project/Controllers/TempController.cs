﻿using Microsoft.AspNetCore.Mvc;
using SEP6_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace SEP6_Project.Controllers
{
    public class TempController : Controller
    {
        DatabaseOperations db = new DatabaseOperations();
        public IActionResult TempIndex()
        {
            return View();
        }

        public JsonResult loadTempJFK()
        {
            TempModel tm = new TempModel();

            tm.temp_JFK = db.getTempFromOrigin("JFK");

            return Json(tm);
        }

        public JsonResult loadTempEWR()
        {
            TempModel tm = new TempModel();

            tm.temp_EWR = db.getTempFromOrigin("EWR");

            return Json(tm);
        }

        public JsonResult loadTempLGA()
        {
            TempModel tm = new TempModel();

            tm.temp_LGA = db.getTempFromOrigin("LGA");

            return Json(tm);
        }

    }
}
