using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
//DbContext class is in System.Data.Entity

namespace BharatiRadio.Models
{
    public class FeedbackContext: DbContext
    {
        public DbSet<Feedback> Feedbacks { get; set; }
    }
}