using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UsersIdentity.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize]
        public ActionResult Index()
        {
            var data = new Dictionary<string, object>();
            data.Add("placeholder", "placeholder");
            return View(data);
        }
    }
}