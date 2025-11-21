using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BharatiRadio.Models
{
    public class SuggestionModel
    {
        [Required, EmailAddress]
        public string email { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        public string contact_no { get; set; }
        public string location { get; set; }
        public string subject { get; set; }
        [Required]
        public string msg { get; set; }
    }
}
