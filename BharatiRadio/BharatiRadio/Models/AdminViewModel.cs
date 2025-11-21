using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BharatiRadio.Models
{
    public class AdminViewModel
    {
        public List<Feedback> Feedbacks { get; set; }
        public List<Bulletin> Bulletins { get; set; }
    }
}