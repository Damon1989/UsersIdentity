using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace UsersIdentity.Controllers
{
    public class ClaimsController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            var ident = HttpContext.User.Identity as ClaimsIdentity;
            if (ident == null)
            {
                return View("Error", new string[] { "No claims available" });
            }
            else
            {
                return View(ident.Claims);
            }
        }
    }
}