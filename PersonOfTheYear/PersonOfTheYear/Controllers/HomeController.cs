using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PersonOfTheYear.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PersonOfTheYear.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Loads initial index page with form
        /// </summary>
        /// <returns>Index page with form</returns>
        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        /// <summary>
        /// Processes the form inputs and passes to Result() 
        /// </summary>
        /// <param name="startYear">First year in range from form</param>
        /// <param name="endYear">Last year in range from form</param>
        /// <returns>Redirects to Result action</returns>
        [HttpPost]
        public IActionResult Index(int startYear, int endYear)
        {
            //Redirect to results view action
            return RedirectToAction("Result", new { startYear, endYear });
        }

        /// <summary>
        /// Retrieves the persons of the year between startYear and endYear and 
        /// renders the Results view
        /// </summary>
        /// <param name="startYear">First year in the range</param>
        /// <param name="endYear">Last year in the range</param>
        /// <returns>The results view</returns>
        public ViewResult Result(int startYear, int endYear)
        {
            //Get List of persons
            List<Person> persons = Person.GetPersons(startYear, endYear);
            return View(persons);
        }



    }
}
