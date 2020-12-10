using Microsoft.AspNetCore.Mvc;
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
            return View();
        }
    }
}
