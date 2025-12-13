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
            var bltn = db.Bulletins.Where(model => model.status == "Published").ToList();

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
            
            //var notices = db.Bulletins.OrderByDescending(x => x.created_at).ToList();

            
             var notices = db.Bulletins.Where(model => model.status == "Published").OrderByDescending(x => x.created_at).ToList();

            // 3. Send the list to the View
            return View(notices);
           
        }
        public ActionResult Podcast()
        {
            return View();
        }

        public ActionResult Article()
        {

            //add data flow here
            return View();
        }
        public ActionResult Videos()
        {
         
            List<Program> videoList = new List<Program>();
          
            videoList.Add(new Program { title = "", description = "PM मोदी ने कोलकाता में भारत की पहली अंडरवाटर मेट्रो रेल सेवा सहित कई परियोजनाओं का शुभारंभ किया।", link = "https://www.youtube.com/embed/fjAAOaWT5DA?si=4FgVEqM_Hyp9q_2x" });
            videoList.Add(new Program { title = "", description = "PM मोदी ने तेलंगाना में 6 हजार आठ सौ करोड़ रूपये से अधिक की परियोजनाओं का लोकार्पण किया।रेडियो भारती", link = "https://www.youtube.com/embed/CelV_jP3KjI?si=Zqr5RFR9asUxzhbS" });
            videoList.Add(new Program { title = "", description = "PM मोदी आज से तेलंगाना, तमिलनाडु, ओडिशा, पश्चिम बंगाल और बिहार के तीन दिन के दौरे पर।Radio Bharati", link = "https://www.youtube.com/embed/E6KCM7A5At8?si=7GWunEdslGJRRprI" });
            videoList.Add(new Program { title = "", description = "PM Modi to be on a two-day visit to Jharkhand, West Bengal and Bihar | Bharati News", link = "https://www.youtube.com/embed/-0vCUMif8v8?si=aHYv2MRvr8OY61ZV" });
            videoList.Add(new Program { title = "", description = "PM Modi to address Viksit Bharat Viksit Rajasthan programme; Inaugurates NH projects. | Bharati News", link = "https://www.youtube.com/embed/4njlZOJ0j58?si=8CST4sv3U0ysfwIS" });
            videoList.Add(new Program { title = "", description = "PM नरेंद्र मोदी की संयुक्त अरब अमीरात और कतर की दो दिन की यात्रा आज से शुरू। Radio Bharati", link = "https://www.youtube.com/embed/7M1x7Nvj1JY?si=-M22TM3lU_VwcGcI" });
            videoList.Add(new Program { title = "", description = "प्रधानमंत्री नरेन्‍द्र मोदी आज नई दिल्ली में नौवें रायसीना संवाद का उद्घाटन करेंगे। Radio Bharati", link = "https://www.youtube.com/embed/8Hekgg8e0uU?si=59LrK2AVhanhG120" });
            videoList.Add(new Program { title = "", description = "PM मोदी ने तमिलनाडु में 17 हजार तीन सौ करोड की परियोजनाएं राष्‍ट्र को समर्पित कि। Radio Bharati", link = "https://www.youtube.com/embed/C26ZYqjh3vw?si=1xc8RuqRP7H7iL8Y" });
            videoList.Add(new Program { title = "", description = "स्वामी प्रसाद के बाद पल्लवी पटेल ने अखि‍लेश को दीया झटका । Radio Bharati", link = "https://www.youtube.com/embed/CjdDKbNBt40?si=oHXCf2CUFvqmsns" });

            return View(videoList);
        }

        public ActionResult Shows()
        {
            var shows = GetShowsList();
            return View(shows);
        }

        private List<Program> GetPrograms()
        {
            List<Program> ProgramVideos = new List<Program>{
                new Program(){link="https://www.youtube.com/embed/QvgHweB1q-A?si=eU2_IQqs_UeH6baw", title = "Navratri 2024", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed/fXLFIvUkWTk?si=Nx9yK8-aRrG5LriN", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed", title = "नव देवी अनंत कथा | Nav Devi Anant Katha |", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Academic"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Academic"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Academic"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Sports"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Sports"},
                new Program(){link="https://www.youtube.com/embed", title = "Radio Bharati | Special program on Education Day", description = "no discription", category = "Sports"}
            };
            return ProgramVideos;
        }

        private List<Program> GetShowsList()
        {
            List<Program> ProgramVideos = new List<Program>{
                new Program(){link="https://www.youtube.com/embed/1jzH6K1kTOQ?si=vwEB09ZRbyNv_yyV", title = " Akbar Birbal Stories | List of three foolish people | Ep 1", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed/p0Wwcdrg0vI?si=VAEQiUYuzt863M8f", title = "Akbar Birbal Stories | The King’s Dream | Ep 2", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed/FhajMwUR3Ec?si=UEueHC6RhSJaQp8c", title = "Akbar Birbal Stories | The Biggest Thing | Ep 3", description = "no discription", category = "Cultural"},
                new Program(){link="https://www.youtube.com/embed/UUH94A45fOs?si=j40qp_2cLTMpT0_3", title = " पंचतंत्र की कहानियां | एपिसोड-1 \"गाय और शेर\"", description = "no discription", category = "kids"},
                new Program(){link="https://www.youtube.com/embed/aJvYWhNNRck?si=BeLgjxd33ql3FmNB", title = "पंचतंत्र की कहानियां | एपिसोड-2 \"जादुई पतीला\"", description = "no discription", category = "kids"},
                new Program(){link="https://www.youtube.com/embed/bW3gD3gkr70?si=zmsVxsoQ9Xw04Y0l", title = " पंचतंत्र की कहानियां | एपिसोड-3 \"शेर और भालू\"", description = "no discription", category = "kids"},
                new Program(){link="https://www.youtube.com/embed/sseZ6o8BH6U?si=5NnJWq3A9KLaavxj", title = "दिल से दिल्ली | राष्ट्रपति भवन EP-1", description = "no discription", category = "journalism"},
                new Program(){link="https://www.youtube.com/embed/lz6m64tEPzk?si=6Yb0mu-LCwZdEl4g", title = "दिल से दिल्ली | कुतुबमीनार EP-2 ", description = "no discription", category = "journalism"},
                new Program(){link="https://www.youtube.com/embed/7sD7N2qpSMA?si=Ysq_XVMFP25aRpWz", title = "दिल से दिल्ली | लोटस टेंपल EP-3", description = "no discription", category = "journalism"}
            };
            return ProgramVideos;
        }


    
    }
    }
