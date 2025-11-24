using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;

namespace BharatiRadio.Controllers
{
    public class FeedbackController : Controller
    {

        FeedbackContext db = new FeedbackContext();
        
         // GET: Feedback
        public ActionResult feedback()
        {
            return View();
        }

        [HttpPost]
        public ActionResult feedback(Feedback f)
        {
            db.Feedbacks.Add(f);
            int a = db.SaveChanges();
            if (ModelState.IsValid == true)
            {
                if (a > 0)
                {
                    //ViewBag.msg = "<script>alert('Thank you for your feedback!');</script>";
                    TempData["msg"] = "<script>alert('Thank you for your feedback!');</script>";
                    return RedirectToAction("Home", "Home");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.msg = "<script>alert('Error in submitting feedback. Please try again.');</script>";
                }
            }
            return View();
        }

        public ActionResult feedbackDashboard()
        {
            var data = db.Feedbacks.ToList();
            return View(data);
        }
    }
}