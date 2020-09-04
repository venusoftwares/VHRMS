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

namespace VHRMS.Internal.Controllers.Common
{
    public class DashboardMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: DashboardMasters
        public async Task<ActionResult> Index()
        {
            var dashboardMaster = db.DashboardMaster.Include(d => d.ConcernMaster);
            return View(await dashboardMaster.ToListAsync());
        }

        // GET: DashboardMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DashboardMaster dashboardMaster = await db.DashboardMaster.FindAsync(id);
            if (dashboardMaster == null)
            {
                return HttpNotFound();
            }
            return View(dashboardMaster);
        }

        // GET: DashboardMasters/Create
        public ActionResult Create()
        {
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName");
            return View();
        }

        // POST: DashboardMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,Dashboard,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DashboardMaster dashboardMaster)
        {
            if (ModelState.IsValid)
            {
                db.DashboardMaster.Add(dashboardMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", dashboardMaster.ConCode);
            return View(dashboardMaster);
        }

        // GET: DashboardMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DashboardMaster dashboardMaster = await db.DashboardMaster.FindAsync(id);
            if (dashboardMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", dashboardMaster.ConCode);
            return View(dashboardMaster);
        }

        // POST: DashboardMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,Dashboard,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DashboardMaster dashboardMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dashboardMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", dashboardMaster.ConCode);
            return View(dashboardMaster);
        }

        // GET: DashboardMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DashboardMaster dashboardMaster = await db.DashboardMaster.FindAsync(id);
            if (dashboardMaster == null)
            {
                return HttpNotFound();
            }
            return View(dashboardMaster);
        }

        // POST: DashboardMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DashboardMaster dashboardMaster = await db.DashboardMaster.FindAsync(id);
            db.DashboardMaster.Remove(dashboardMaster);
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
