using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;
using MVCApp.Db.DbOperations;


namespace BharatiRadio.Controllers
{
    public class FeedbackController : Controller
    {
        SuggestionRepository repository = null;

        public FeedbackController()
        {
            repository = new SuggestionRepository();

        }

        // GET: Feedback
        public ActionResult feedback()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(SuggestionModel model)
        {
            if (ModelState.IsValid)
            {
                int id = repository.addSuggestion(model);
                if (id > 0)
                {
                    ModelState.Clear();

                    ViewBag.IsSuccess = "Data is Added.";
                }
            }
            return View();
        }
    }
}