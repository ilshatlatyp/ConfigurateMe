using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Web.Http;
using ConfigurateMe.Models.Main;

namespace ConfigurateMe.Controllers
{
    public class BookmarkApiController : ApiController
    {
        private ConfiguratorDBContext db = new ConfiguratorDBContext();

        public List<Bookmark> GetBookmarks(string AccountName)
        {

            return db.BookmarkSet.Include(b => b.Options)
                .Include(z=>z.Company)
                .Where(x => x.Company.AccountName == AccountName)
                .ToList();
        }
    }
}
