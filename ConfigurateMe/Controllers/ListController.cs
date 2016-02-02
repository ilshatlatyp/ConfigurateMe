using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ConfigurateMe.Models.Main;

namespace ConfigurateMe.Controllers
{
    public class ListController : Controller
    {
        ConfiguratorDBContext db = new ConfiguratorDBContext();
        // GET: List
        public ActionResult Index()
        {
            string AccountName = RouteData.Values["id"].ToString();
            if (AccountName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.CompanySet.Where(x => x.AccountName == AccountName).First();
            if (company == null)
            {
                return HttpNotFound();
            }

            ViewBag.CompanyName = company.Name;
            ViewBag.CompanyAdr = company.Address;
            ViewBag.CompanyPhone = company.Phone;

            return View();
        }
    }
}