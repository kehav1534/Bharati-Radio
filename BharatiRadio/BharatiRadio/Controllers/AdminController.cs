using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;
using System.Data.Entity;
using System.Data.Entity.Migrations;
namespace BharatiRadio.Controllers
{
    public class AdminController : Controller
    {
        RadioContext db = new RadioContext();

        // GET: Admin
        [Authorize]
        public ActionResult Index()
        {
            var viewModel = new AdminViewModel
            {
                Feedbacks = db.Feedbacks.ToList(),
                Bulletins = db.Bulletins.ToList()
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
            if (feedback.viewed == 0)
            {
                feedback.viewed = 1;
                db.SaveChanges();
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
                msg = feedback.msg,
                mark = feedback.marked
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewBulletin(String id)
        {
            var bltn = db.Bulletins.Find(int.Parse(id));
            if (bltn == null)
            {
                return Json(new { success = false, message = "Not Found." },
                    JsonRequestBehavior.AllowGet);
            }
            var data = new
            {
                success = true,
                id = bltn.Id,
                title = bltn.title,
                link = bltn.link,
                status = bltn.status,
                content = bltn.content,
                tag = bltn.tag
            };
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult NewBulletin(Bulletin b)
        {
            b.created_at = DateTime.Now;
            b.updated_at = DateTime.Now;
            b.link = b.title.Trim();
            db.Bulletins.Add(b);
            int a = db.SaveChanges();

            if (ModelState.IsValid == true)
            {
                if (a > 0)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    ViewBag.msg = "<script>alert('Error in submitting feedback. Please try again.');</script>";
                }
            }
            return RedirectToAction("Index", "Admin");
        }

        public ActionResult EditBulletin(int id)
        {
            var row = db.Bulletins.Where(model => model.Id == id).FirstOrDefault();
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult EditBulletin(Bulletin b)
        {
            var row = db.Bulletins.Where(model => model.Id == b.Id).FirstOrDefault();
            if (row==null)
            {
                TempData["msg"] = "Bulletin not found.";
                return RedirectToAction("Index", "Admin");
            }
            b.updated_at = DateTime.Now;
            row.title = b.title;
            row.content = b.content;
            row.status = b.status;
            row.tag = b.tag;
            int a = db.SaveChanges();
            if (a > 0)
            {
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                TempData["msg"] = "Error in updating bulletin. Please try again.";
            }
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult DeleteBulletin(int Id)
        {
            var row = db.Bulletins.Where(model=> model.Id == Id ).FirstOrDefault();
            if(row!=null)
            { 
                db.Bulletins.Remove(row);
                int a = db.SaveChanges();
            }
            
            return RedirectToAction("Index", "Admin");
        }


        [HttpPost]
        public ActionResult DeleteSuggestion(int Id)
        {
            var f = db.Feedbacks.Where(model => model.Id == Id).FirstOrDefault();
            if (f != null)
            {
                db.Feedbacks.Remove(f);
                int a = db.SaveChanges();
            }

            return RedirectToAction("Index", "Admin");
        }
        [HttpPost]
        public ActionResult Bookmark(int id)
        {
            var mark = db.Feedbacks.Where(modal => modal.Id == id).FirstOrDefault();
            if (mark != null)
            {
                mark.marked = mark.marked == 1 ? 0 : 1;
            }
            int a= db.SaveChanges();
            if (a > 0)
            {
                return Json(new {success = true}, JsonRequestBehavior.DenyGet);

            }
            return Json(new { success = false, message = "Not Found." },
                    JsonRequestBehavior.DenyGet);
        }
    }
}