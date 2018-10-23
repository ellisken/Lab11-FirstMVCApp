using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        //Loads initial index page with form
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        //Processes form submission
        //[HttpPost]
        //public IActionResult Index(int startYear, int endYear)
        //{
        //    //Redirect to results view action
        //    return RedirectToAction("Result", new { startYear, endYear });
        //}



    }
}
