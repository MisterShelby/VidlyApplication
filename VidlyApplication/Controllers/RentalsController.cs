using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VidlyApplication.Controllers
{
    public class RentalsController : Controller
    {
        [AllowAnonymous]
        public ActionResult New()
        {
            return View();
        }
    }
}