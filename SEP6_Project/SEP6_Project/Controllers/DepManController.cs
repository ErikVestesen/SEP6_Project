using Microsoft.AspNetCore.Mvc;
using SEP6_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEP6_Project.Controllers
{
    public class DepManController : Controller
    {
        public IActionResult Depindex()
        { 
            return View(LoadModel());
        }


        public DepManModel LoadModel()
        {
            DepManModel dm = new DepManModel();
            DatabaseOperations db = new DatabaseOperations();

            double[] ewr = db.getMeanDepArr("EWR");
            double[] lga = db.getMeanDepArr("LGA");
            double[] jfk = db.getMeanDepArr("JFK");

            dm.mean_dep_EWR = ewr[0];
            dm.mean_arr_EWR = ewr[1];

            dm.mean_dep_LGA = lga[0];
            dm.mean_arr_LGA = lga[1];

            dm.mean_dep_JFK = jfk[0];
            dm.mean_arr_JFK = jfk[1];

            dm.manufacturers_with_flights = db.getManufacturersFlight();

            dm.big_manufacturers = db.getBigManufacturers();

            dm.airbus_models = db.getAirbusModels();

            return dm;
        }


        public JsonResult GetMeanDepArr()
        {
            DepManModel dm = new DepManModel();
            DatabaseOperations db = new DatabaseOperations();

            double[] ewr = db.getMeanDepArr("EWR");
            double[] lga = db.getMeanDepArr("LGA");
            double[] jfk = db.getMeanDepArr("JFK");

            dm.mean_dep_JFK = ewr[0];
            dm.mean_arr_JFK = ewr[1];

            dm.mean_dep_LGA = lga[0];
            dm.mean_arr_LGA = lga[1];

            dm.mean_dep_JFK = jfk[0];
            dm.mean_arr_JFK = jfk[1];

            return Json(dm);
        }


        public JsonResult GetBigManufacturers()
        {
            DepManModel dm = new DepManModel();
            DatabaseOperations db = new DatabaseOperations();

            dm.big_manufacturers = db.getBigManufacturers();

            return Json(dm);
        }

        public JsonResult GetManufacturersFlight()
        {
            DepManModel dm = new DepManModel();
            DatabaseOperations db = new DatabaseOperations();

            dm.manufacturers_with_flights = db.getManufacturersFlight();

            return Json(dm);
        }
        
        public JsonResult GetAirbusModels()
        {
            DepManModel dm = new DepManModel();
            DatabaseOperations db = new DatabaseOperations();

            dm.airbus_models = db.getAirbusModels();

            return Json(dm);
        }
    }
}
