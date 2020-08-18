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
    public class PermissionRolesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PermissionRoles
        public async Task<ActionResult> Index()
        {
            var permissionRoles = db.PermissionRoles.Include(p => p.PageMaster).Include(p => p.UserRole);
            return View(await permissionRoles.ToListAsync());
        }

        // GET: PermissionRoles/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionRole permissionRole = await db.PermissionRoles.FindAsync(id);
            if (permissionRole == null)
            {
                return HttpNotFound();
            }
            return View(permissionRole);
        }

        // GET: PermissionRoles/Create
        public ActionResult Create()
        {
            ViewBag.PageId = new SelectList(db.PageMasters, "Id", "Page");
            ViewBag.RoleId = new SelectList(db.UserRoles, "id", "Role");
            return View();
        }

        // POST: PermissionRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,PageId,RoleId,Add,Edit,View,Delete,CreatedDate,ModifyDate,ConCode")] PermissionRole permissionRole)
        {
            if (ModelState.IsValid)
            {
                db.PermissionRoles.Add(permissionRole);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PageId = new SelectList(db.PageMasters, "Id", "Page", permissionRole.PageId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "id", "Role", permissionRole.RoleId);
            return View(permissionRole);
        }

        // GET: PermissionRoles/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionRole permissionRole = await db.PermissionRoles.FindAsync(id);
            if (permissionRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.PageId = new SelectList(db.PageMasters, "Id", "Page", permissionRole.PageId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "id", "Role", permissionRole.RoleId);
            return View(permissionRole);
        }

        // POST: PermissionRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,PageId,RoleId,Add,Edit,View,Delete,CreatedDate,ModifyDate,ConCode")] PermissionRole permissionRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissionRole).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PageId = new SelectList(db.PageMasters, "Id", "Page", permissionRole.PageId);
            ViewBag.RoleId = new SelectList(db.UserRoles, "id", "Role", permissionRole.RoleId);
            return View(permissionRole);
        }

        // GET: PermissionRoles/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionRole permissionRole = await db.PermissionRoles.FindAsync(id);
            if (permissionRole == null)
            {
                return HttpNotFound();
            }
            return View(permissionRole);
        }

        // POST: PermissionRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PermissionRole permissionRole = await db.PermissionRoles.FindAsync(id);
            db.PermissionRoles.Remove(permissionRole);
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
