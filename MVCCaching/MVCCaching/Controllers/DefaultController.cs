using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCaching.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        [OutputCache(Duration = 60)]
        public String Index()
        {
            return DateTime.Now.ToString("T");
        }
    }
}