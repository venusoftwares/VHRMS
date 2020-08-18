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
    public class ConcernMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ConcernMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.ConcernMasters.ToListAsync());
        }

        // GET: ConcernMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcernMaster concernMaster = await db.ConcernMasters.FindAsync(id);
            if (concernMaster == null)
            {
                return HttpNotFound();
            }
            return View(concernMaster);
        }

        // GET: ConcernMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ConcernMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Concern,Address,CreatedDate,ModifyDate")] ConcernMaster concernMaster)
        {
            if (ModelState.IsValid)
            {
                db.ConcernMasters.Add(concernMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(concernMaster);
        }

        // GET: ConcernMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcernMaster concernMaster = await db.ConcernMasters.FindAsync(id);
            if (concernMaster == null)
            {
                return HttpNotFound();
            }
            return View(concernMaster);
        }

        // POST: ConcernMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Concern,Address,CreatedDate,ModifyDate")] ConcernMaster concernMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(concernMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(concernMaster);
        }

        // GET: ConcernMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ConcernMaster concernMaster = await db.ConcernMasters.FindAsync(id);
            if (concernMaster == null)
            {
                return HttpNotFound();
            }
            return View(concernMaster);
        }

        // POST: ConcernMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ConcernMaster concernMaster = await db.ConcernMasters.FindAsync(id);
            db.ConcernMasters.Remove(concernMaster);
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
