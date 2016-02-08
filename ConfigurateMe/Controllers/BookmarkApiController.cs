using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using ConfigurateMe.Models.Main;
using System.Data.SqlClient;

namespace ConfigurateMe.Controllers
{
    public class BookmarkApiController : ApiController
    {
        private ConfiguratorDBContext db = new ConfiguratorDBContext();

        public Company GetBookmarks(string id)
        {
            return db.CompanySet.Include(p => p.Bookmarks.Select(o => o.Options))
                .Where(x => x.AccountName == id)
                .First();
                    
        }

        [HttpPost]
        public int InsertBookmarks(Bookmark bookmark)
        {
            db.BookmarkSet.Add(bookmark);

            return db.SaveChanges();
        }

        [HttpPut]
        public int UpdateBookmark(Bookmark bookmark)
        {
            db.Entry(bookmark).State = EntityState.Modified;

            return db.SaveChanges();
        }

    }
}
