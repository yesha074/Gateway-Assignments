using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCControllerDemo.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Custom
        [OutputCache(Duration = 60)]
        public String Index()
        {
            return DateTime.Now.ToString("T");
        }
        public ActionResult Search(string name)
        {
            var input = Server.HtmlEncode(name);
            return Content(input);
        }
        [HttpGet]
        public ActionResult Search()
        {
            var input = "Another Search action";
            return Content(input);
        }
        public string GetAllCustomers()
        {
            return @"<ul>
      <li>Ali Raza</li>
      <li>Mark Upston</li>
      <li>Allan Bommer</li>
      <li>Greg Jerry</li>
   </ul>";
        }
    }
}