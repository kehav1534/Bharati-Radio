using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace BharatiRadio.Models
{
    public class Bulletin
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public string status { get; set; }
        public string content { get; set; }
        public string tag { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}