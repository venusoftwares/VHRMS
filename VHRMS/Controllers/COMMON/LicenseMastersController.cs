using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VHRMS.Models;

namespace VHRMS.Controllers.COMMON
{
    public class LicenseMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: LicenseMasters
        public async Task<ActionResult> Index()
        {
            var licenseMasters = db.LicenseMasters.Include(l => l.ConcernMaster);
            return View(await licenseMasters.ToListAsync());
        }

        // GET: LicenseMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseMaster licenseMaster = await db.LicenseMasters.FindAsync(id);
            if (licenseMaster == null)
            {
                return HttpNotFound();
            }
            return View(licenseMaster);
        }

        // GET: LicenseMasters/Create
        public ActionResult Create()
        {
            ViewBag.ConCode = new SelectList(db.ConcernMasters, "id", "Concern");
            return View();
        }

        // POST: LicenseMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Lid,A,B,ConCode,CreatedDate,UserId,ModifyDate")] LicenseMaster licenseMaster)
        {
            if (ModelState.IsValid)
            {
                db.LicenseMasters.Add(licenseMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConCode = new SelectList(db.ConcernMasters, "id", "Concern", licenseMaster.ConCode);
            return View(licenseMaster);
        }

        // GET: LicenseMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseMaster licenseMaster = await db.LicenseMasters.FindAsync(id);
            if (licenseMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConCode = new SelectList(db.ConcernMasters, "id", "Concern", licenseMaster.ConCode);
            return View(licenseMaster);
        }

        // POST: LicenseMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Lid,A,B,ConCode,CreatedDate,UserId,ModifyDate")] LicenseMaster licenseMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(licenseMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConCode = new SelectList(db.ConcernMasters, "id", "Concern", licenseMaster.ConCode);
            return View(licenseMaster);
        }

        // GET: LicenseMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LicenseMaster licenseMaster = await db.LicenseMasters.FindAsync(id);
            if (licenseMaster == null)
            {
                return HttpNotFound();
            }
            return View(licenseMaster);
        }

        // POST: LicenseMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LicenseMaster licenseMaster = await db.LicenseMasters.FindAsync(id);
            db.LicenseMasters.Remove(licenseMaster);
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
