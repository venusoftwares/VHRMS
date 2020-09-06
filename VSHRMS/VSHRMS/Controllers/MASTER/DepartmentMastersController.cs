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
using VSHRMS.ViewModels.JQUERYDATATABLES;
using VSHRMS.Repository.Repository;
using VSHRMS.Repository.Interface.MASTER;
using VSHRMS.ViewModels.MASTER;
using VSHRMS.Providers;

namespace VSHRMS.Controllers.MASTER
{
    [Authentication]
    public class DepartmentMastersController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        private readonly IDepartmentMasters _departmentMasters;
        public DepartmentMastersController()
        {
            this._departmentMasters = new DepartmentMastersRepository();
        }
        //

        // GET: DepartmentMasters
        public  ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentMaster departmentMaster = await db.DepartmentMaster.FindAsync(id);
            if (departmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(departmentMaster);
        }

        // GET: DepartmentMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,DepartmentName,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DepartmentMaster departmentMaster)
        {
            if (ModelState.IsValid)
            {
                departmentMaster.DepartmentName = departmentMaster.DepartmentName.ToUpper();
                departmentMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                departmentMaster.CreatedBy = Convert.ToInt64(Session["UserId"]);
                departmentMaster.CreatedAt = DateTime.Now;
                db.DepartmentMaster.Add(departmentMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(departmentMaster);
        }

        // GET: DepartmentMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentMaster departmentMaster = await db.DepartmentMaster.FindAsync(id);
            if (departmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(departmentMaster);
        }

        // POST: DepartmentMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,DepartmentName,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] DepartmentMaster departmentMaster)
        {
            if (ModelState.IsValid)
            {
                departmentMaster.DepartmentName = departmentMaster.DepartmentName.ToUpper();
                departmentMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                departmentMaster.UpdatedBy = Convert.ToInt64(Session["UserId"]);
                departmentMaster.UpdatedAt = DateTime.Now;
                db.Entry(departmentMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(departmentMaster);
        }

        // GET: DepartmentMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DepartmentMaster departmentMaster = await db.DepartmentMaster.FindAsync(id);
            if (departmentMaster == null)
            {
                return HttpNotFound();
            }
            return View(departmentMaster);
        }

        // POST: DepartmentMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            DepartmentMaster departmentMaster = await db.DepartmentMaster.FindAsync(id);
            db.DepartmentMaster.Remove(departmentMaster);
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
            var departmentMasterViewModels   = _departmentMasters.GetDepartmentMasterDetails(); //This method is returning the IEnumerable employee from database 
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                departmentMasterViewModels = departmentMasterViewModels.Where(x => x.Department.ToLower().Contains(param.sSearch.ToLower())                                              ).ToList();
            }
            var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
            var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];
            if (sortColumnIndex == 2)
            {
                departmentMasterViewModels = sortDirection == "asc" ? departmentMasterViewModels.OrderBy(c => c.Department) : departmentMasterViewModels.OrderByDescending(c => c.Department);
            }
          
            else
            {
                Func<DepartmentMasterViewModel, string> orderingFunction = e => sortColumnIndex == 0 ? e.Department : sortColumnIndex == 1 ? e.Department : e.Department;
                departmentMasterViewModels = sortDirection == "asc" ? departmentMasterViewModels.OrderBy(orderingFunction) : departmentMasterViewModels.OrderByDescending(orderingFunction);
            }
            var displayResult = departmentMasterViewModels.Skip(param.iDisplayStart)
               .Take(param.iDisplayLength).OrderBy(x => x.Id).ToList();
            var totalRecords = departmentMasterViewModels.Count();
            return Json(new { param.sEcho, iTotalRecords = totalRecords, iTotalDisplayRecords = totalRecords, aaData = displayResult }, JsonRequestBehavior.AllowGet);
        }

    }
}
