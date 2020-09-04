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
    public class RolePermissionMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: RolePermissionMasters
        public async Task<ActionResult> Index()
        {
            var rolePermissionMaster = db.RolePermissionMaster.Include(r => r.RoleMaster);
            return View(await rolePermissionMaster.ToListAsync());
        }

        // GET: RolePermissionMasters/Details/5
        public async Task<ActionResult> Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermissionMaster rolePermissionMaster = await db.RolePermissionMaster.FindAsync(id);
            if (rolePermissionMaster == null)
            {
                return HttpNotFound();
            }
            return View(rolePermissionMaster);
        }

        // GET: RolePermissionMasters/Create
        public ActionResult Create()
        {
            ViewBag.RoleCode = new SelectList(db.RoleMaster, "id", "Role");
            return View();
        }

        // POST: RolePermissionMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,RoleCode,Add,Edit,View,Delete,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] RolePermissionMaster rolePermissionMaster)
        {
            if (ModelState.IsValid)
            {
                db.RolePermissionMaster.Add(rolePermissionMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.RoleCode = new SelectList(db.RoleMaster, "id", "Role", rolePermissionMaster.RoleCode);
            return View(rolePermissionMaster);
        }

        // GET: RolePermissionMasters/Edit/5
        public async Task<ActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermissionMaster rolePermissionMaster = await db.RolePermissionMaster.FindAsync(id);
            if (rolePermissionMaster == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleCode = new SelectList(db.RoleMaster, "id", "Role", rolePermissionMaster.RoleCode);
            return View(rolePermissionMaster);
        }

        // POST: RolePermissionMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,RoleCode,Add,Edit,View,Delete,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] RolePermissionMaster rolePermissionMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolePermissionMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.RoleCode = new SelectList(db.RoleMaster, "id", "Role", rolePermissionMaster.RoleCode);
            return View(rolePermissionMaster);
        }

        // GET: RolePermissionMasters/Delete/5
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RolePermissionMaster rolePermissionMaster = await db.RolePermissionMaster.FindAsync(id);
            if (rolePermissionMaster == null)
            {
                return HttpNotFound();
            }
            return View(rolePermissionMaster);
        }

        // POST: RolePermissionMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(long id)
        {
            RolePermissionMaster rolePermissionMaster = await db.RolePermissionMaster.FindAsync(id);
            db.RolePermissionMaster.Remove(rolePermissionMaster);
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
