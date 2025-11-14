using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BharatiRadio.Controllers
{
    public class ShowsController : Controller
    {
        // GET: Shows
        public ActionResult Show()
        {
            return View();
        }
        public ActionResult AddShows()
        {
            return View();
        }
        public ActionResult GetList()
        {
            return View();
        }
    }
}