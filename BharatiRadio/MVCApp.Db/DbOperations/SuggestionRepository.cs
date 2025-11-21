using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BharatiRadio.Models;

namespace MVCApp.Db.DbOperations
{
    public class SuggestionRepository
    {
        public int addSuggestion(SuggestionModel model)
        {
            using(var context = new RadioBharatiEntities1())
            {
                Suggestion suggest = new Suggestion()
                {
                    email = model.email,
                    name = model.name,
                    contact_no = model.contact_no,
                    location = model.location,
                    subject = model.subject,
                    msg = model.msg
                };
                context.Suggestion.Add(suggest);

                context.SaveChanges(); //Need to save changes

                return suggest.id;  //The whole data will be synced with database and returns the id.
            }
        }
    }
}