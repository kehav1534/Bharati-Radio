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
        public ActionResult Home()
        {
            return View();
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
            var data = GetEmployee();
            return View(data);
        }
        private Employee GetEmployee()
        {
            return new Employee()
            {
                Id = 1,
                Name = "Keshav",
                Address = "India"
            };
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