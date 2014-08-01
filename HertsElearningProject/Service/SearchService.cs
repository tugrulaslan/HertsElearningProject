using HertsElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Service
{
    public class SearchService
    {
        HertsOnlineEntities db = new HertsOnlineEntities();
        String hitTimeStamp = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public void updateSearchHit(String Keyword)
        {
            var query = db.SearchEntity.Where(x => x.Keyword == Keyword).Count();
            if (query > 0)
            {
                //search keyword exists
                Search search = db.SearchEntity.Where(x => x.Keyword == Keyword).FirstOrDefault();
                search.Hit += 1;
                search.SearchTimeStamp = hitTimeStamp;
                db.Entry(search).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                Search search = new Search();
                search.Keyword = Keyword;
                search.Hit = 1;
                search.SearchTimeStamp = hitTimeStamp;
                db.SearchEntity.Add(search);
                db.SaveChanges();
                //search keyword does not exist
            }
        }
    }
}