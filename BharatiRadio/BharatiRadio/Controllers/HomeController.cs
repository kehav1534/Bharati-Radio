using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BharatiRadio.Models;
namespace BharatiRadio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        RadioContext db = new RadioContext();

        public ActionResult Home()
        {
            var bltn = db.Bulletins.Where(model=> model.status=="Published").ToList();

            return View(bltn);
        }
        public ActionResult Programs()
        {
            var videos = GetPrograms();
            return View(videos);
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
        public ActionResult Bulletin()
        {
            return View();
        }
        public ActionResult Podcast()
        {
            return View();
        }
        public ActionResult Videos()
        {
            return View();
        }
        private List<Program> GetPrograms()
        {
             List<Program> ProgramVideos = new List<Program>{
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day"}
            };
            return ProgramVideos;
        }
    }
}