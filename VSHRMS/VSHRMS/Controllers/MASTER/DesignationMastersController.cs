using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VSHRMS.Models;
using VSHRMS.Repository.Interface.MASTER;
using VSHRMS.Repository.Repository;
using VSHRMS.ViewModels.JQUERYDATATABLES;
using VSHRMS.ViewModels.MASTER;
using VSHRMS.Providers;

namespace VSHRMS.Controllers.MASTER
{
    [Authentication]
    public class DesignationMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private readonly IDesignationMasters _designationMasters;
        public DesignationMastersController()
        {
            this._designationMasters = new DesignationMastersRepository();
        }
        // GET: DesignationMasters
        public ActionResult Index()
        {
            return View( );
        }

        // GET: DesignationMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = await db.DesignationMaster.FindAsync(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // GET: DesignationMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesignationMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DesignationName,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DesignationMaster designationMaster)
        {
            if (ModelState.IsValid)
            {
                designationMaster.DesignationName = designationMaster.DesignationName.ToUpper();
                designationMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                designationMaster.CreatedBy = Convert.ToInt64(Session["UserId"]);
                designationMaster.CreatedAt = DateTime.Now;
                db.DesignationMaster.Add(designationMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(designationMaster);
        }

        // GET: DesignationMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = await db.DesignationMaster.FindAsync(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // POST: DesignationMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DesignationName,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DesignationMaster designationMaster)
        {
            if (ModelState.IsValid)
            {
        
                designationMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                designationMaster.UpdatedBy = Convert.ToInt64(Session["UserId"]);
                designationMaster.UpdatedAt = DateTime.Now;
                db.Entry(designationMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(designationMaster);
        }

        // GET: DesignationMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesignationMaster designationMaster = await db.DesignationMaster.FindAsync(id);
            if (designationMaster == null)
            {
                return HttpNotFound();
            }
            return View(designationMaster);
        }

        // POST: DesignationMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DesignationMaster designationMaster = await db.DesignationMaster.FindAsync(id);
            db.DesignationMaster.Remove(designationMaster);
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
        public ActionResult GetData(JqueryDatatableParam param)
        {
            var designationMasterViewModels  = _designationMasters.GetDesignationMasterDetails(); //This method is returning the IEnumerable employee from database 
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                designationMasterViewModels = designationMasterViewModels.Where(x => x.Designation.ToLower().Contains(param.sSearch.ToLower())).ToList();
            }
            var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
            var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];
            if (sortColumnIndex == 2)
            {
                designationMasterViewModels = sortDirection == "asc" ? designationMasterViewModels.OrderBy(c => c.Designation) : designationMasterViewModels.OrderByDescending(c => c.Designation);
            }

            else
            {
                Func<DesignationMasterViewModel, string> orderingFunction = e => sortColumnIndex == 0 ? e.Designation : sortColumnIndex == 1 ? e.Designation : e.Designation;
                designationMasterViewModels = sortDirection == "asc" ? designationMasterViewModels.OrderBy(orderingFunction) : designationMasterViewModels.OrderByDescending(orderingFunction);
            }
            var displayResult = designationMasterViewModels.Skip(param.iDisplayStart)
               .Take(param.iDisplayLength).OrderBy(x => x.Id).ToList();
            var totalRecords = designationMasterViewModels.Count();
            return Json(new { param.sEcho, iTotalRecords = totalRecords, iTotalDisplayRecords = totalRecords, aaData = displayResult }, JsonRequestBehavior.AllowGet);
        }
    }
}
