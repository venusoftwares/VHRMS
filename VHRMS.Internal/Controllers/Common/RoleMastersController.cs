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
    public class RoleMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: RoleMasters
        public async Task<ActionResult> Index()
        {
            var roleMaster = db.RoleMaster.Include(r => r.ConcernMaster).Include(r => r.DashboardMaster);
            return View(await roleMaster.ToListAsync());
        }

        // GET: RoleMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = await db.RoleMaster.FindAsync(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            return View(roleMaster);
        }

        // GET: RoleMasters/Create
        public ActionResult Create()
        {
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName");
            ViewBag.DashCode = new SelectList(db.DashboardMaster, "id", "Dashboard");
            return View();
        }

        // POST: RoleMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DashCode,Role,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] RoleMaster roleMaster)
        {
            if (ModelState.IsValid)
            {
                db.RoleMaster.Add(roleMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", roleMaster.ConCode);
            ViewBag.DashCode = new SelectList(db.DashboardMaster, "id", "Dashboard", roleMaster.DashCode);
            return View(roleMaster);
        }

        // GET: RoleMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = await db.RoleMaster.FindAsync(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", roleMaster.ConCode);
            ViewBag.DashCode = new SelectList(db.DashboardMaster, "id", "Dashboard", roleMaster.DashCode);
            return View(roleMaster);
        }

        // POST: RoleMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DashCode,Role,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] RoleMaster roleMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ConCode = new SelectList(db.ConcernMaster, "id", "ConcernName", roleMaster.ConCode);
            ViewBag.DashCode = new SelectList(db.DashboardMaster, "id", "Dashboard", roleMaster.DashCode);
            return View(roleMaster);
        }

        // GET: RoleMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleMaster roleMaster = await db.RoleMaster.FindAsync(id);
            if (roleMaster == null)
            {
                return HttpNotFound();
            }
            return View(roleMaster);
        }

        // POST: RoleMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            RoleMaster roleMaster = await db.RoleMaster.FindAsync(id);
            db.RoleMaster.Remove(roleMaster);
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
