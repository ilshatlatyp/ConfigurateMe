using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ConfigurateMe.Models.Main;
using System.Threading.Tasks;
using System.Net;
using System.Data.Entity;

namespace ConfigurateMe.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        ConfiguratorDBContext db = new ConfiguratorDBContext();

        // GET: Companies/Details/5
        public ActionResult Details()
        {
            string AccountName = RouteData.Values["id"].ToString();
            if (AccountName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.CompanySet.Where(x=>x.AccountName==AccountName).First();
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            if (db.RateSet.Any() == false)
            {
                Rate rate = new Rate();
                rate.Name = "Тариф 1";
                rate.Price = 1000;
                db.RateSet.Add(rate);
                db.SaveChanges();
            }
            string AccountName = RouteData.Values["id"].ToString();
            ViewBag.AccountName = AccountName;
            return View();
        }

        // POST: Companies/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "CompanyId,Name,Balance,AccountName,Logo,DateOfRegistration,Address,Phone")] Company company)
        {
            if (ModelState.IsValid)
            {
                company.AccountName = RouteData.Values["id"].ToString();
                company.DateOfRegistration = DateTime.Now;
                company.CompanyRate = db.RateSet.First(); //осторожнее!
                db.CompanySet.Add(company);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit()
        {
            string AccountName = RouteData.Values["id"].ToString();
            if (AccountName == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.CompanySet.Where(x=>x.AccountName == AccountName).First();
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "CompanyId,Name,Balance,AccountName,Logo,DateOfRegistration,Address,Phone")] Company company)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(company);
        }

        // GET: Companies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = await db.CompanySet.FindAsync(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Company company = await db.CompanySet.FindAsync(id);
            db.CompanySet.Remove(company);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}