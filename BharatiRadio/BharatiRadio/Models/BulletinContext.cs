using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace BharatiRadio.Models
{
    public class BulletinContext: DbContext
    {
        public DbSet<Bulletin> Bulletins { get; set; }
    }
}