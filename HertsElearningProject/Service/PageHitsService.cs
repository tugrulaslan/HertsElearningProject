using HertsElearningProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HertsElearningProject.Service
{
    public class PageHitsService
    {
        HertsOnlineEntities db = new HertsOnlineEntities();
        String hitTimeStamp = DateTime.Now.ToString("dd/MM/yyyy H:mm");
        public void updatePageHit(String pageName, String userName)
        {
            var pageCount = db.PageHitsEntity.Where(x => x.PageName == pageName && x.Username == userName).Count();
            if (pageCount > 0)
            {
                PageHits pageHitsModel = new PageHits();
                pageHitsModel.PageName = pageName;
                pageHitsModel.Username = userName;

                PageHits updateHit = db.PageHitsEntity.Where(f => f.PageName == pageHitsModel.PageName && f.Username == pageHitsModel.Username).FirstOrDefault();
                updateHit.Hit += 1;
                updateHit.LastVisitStamp = hitTimeStamp;
                db.Entry(updateHit).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                PageHits pageHitsModel = new PageHits();
                pageHitsModel.PageName = pageName;
                pageHitsModel.Username = userName;
                pageHitsModel.Hit = 1;
                pageHitsModel.LastVisitStamp = hitTimeStamp;
                db.PageHitsEntity.Add(pageHitsModel);
                db.SaveChanges();
            }
        }
    }
}