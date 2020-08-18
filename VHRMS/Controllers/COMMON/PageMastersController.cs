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
    public class PageMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: PageMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.PageMasters.ToListAsync());
        }

        // GET: PageMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageMaster pageMaster = await db.PageMasters.FindAsync(id);
            if (pageMaster == null)
            {
                return HttpNotFound();
            }
            return View(pageMaster);
        }

        // GET: PageMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PageMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Page,CreatedDate,ModifyDate")] PageMaster pageMaster)
        {
            if (ModelState.IsValid)
            {
                db.PageMasters.Add(pageMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(pageMaster);
        }

        // GET: PageMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageMaster pageMaster = await db.PageMasters.FindAsync(id);
            if (pageMaster == null)
            {
                return HttpNotFound();
            }
            return View(pageMaster);
        }

        // POST: PageMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Page,CreatedDate,ModifyDate")] PageMaster pageMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pageMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(pageMaster);
        }

        // GET: PageMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PageMaster pageMaster = await db.PageMasters.FindAsync(id);
            if (pageMaster == null)
            {
                return HttpNotFound();
            }
            return View(pageMaster);
        }

        // POST: PageMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            PageMaster pageMaster = await db.PageMasters.FindAsync(id);
            db.PageMasters.Remove(pageMaster);
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
