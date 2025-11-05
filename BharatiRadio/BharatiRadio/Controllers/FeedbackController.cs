using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BharatiRadio.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult feedback()
        {
            return View();
        }
    }
}