using MVCFiltersDemo.ActionFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFiltersDemo.Controllers
{
    [MyLogActionFilter]
    public class HomeController : Controller
    {
        // GET: Home
        [OutputCache(Duration = 15)]

        public string Index()
        {
            return "This is ASP.Net MVC Filters Tutorial";
        }
        [ActionName("CurrentTime")]
        public string GetCurrentTime()
        {
            return TimeString();
        }
        [NonAction]
        public string TimeString()
        {
            return "Time is " + DateTime.Now.ToString("T");
        }
    }
}