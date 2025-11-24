using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;
namespace BharatiRadio.Controllers
{
    public class AdminController : Controller
    {
        FeedbackContext db = new FeedbackContext();
        BulletinContext b_db = new BulletinContext();

        // GET: Admin
        public ActionResult Index()
        {
            var viewModel = new AdminViewModel
            {
                Feedbacks = db.Feedbacks.ToList(),
                Bulletins = b_db.Bulletins.ToList()
            };
            return View(viewModel);
        }

        public ActionResult ViewSuggestion(String id)
        {
            var feedback = db.Feedbacks.Find(int.Parse(id));
            if (feedback == null)
            {
                return Json(new { success = false, message = "Not found" },
                    JsonRequestBehavior.AllowGet);
            }
            var data = new
            {
                success = true,
                id = feedback.Id,
                email = feedback.email,
                name = feedback.name,
                contact_no = feedback.contact_no,
                location = feedback.location,
                sub = feedback.subject,
                msg = feedback.msg
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}