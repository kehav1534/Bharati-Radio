using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace BharatiRadio.Models
{
    public class Auth
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Username is required.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        public string password { get; set; }
    }
}