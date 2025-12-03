using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BharatiRadio.Models
{
    public class RadioContext : DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<Auth> Auths { get; set; }
    }
}