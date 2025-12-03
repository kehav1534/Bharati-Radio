using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
namespace BharatiRadio.Models
{
    public class Feedback  
    {
        [Key]
        public int Id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string contact_no { get; set; }
        public string location { get; set; }
        public string subject { get; set; }
        public string msg { get; set; }
        public int marked { get; set; }
        public int viewed { get; set; }
    }
}