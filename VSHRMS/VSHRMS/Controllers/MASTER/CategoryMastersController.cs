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
using VSHRMS.Providers;
using VSHRMS.ViewModels.JQUERYDATATABLES;
using VSHRMS.Repository.Interface;
using VSHRMS.Repository.Repository;
using VSHRMS.ViewModels.ERP;

namespace VSHRMS.Controllers.MASTER
{
    [Authentication]
    public class CategoryMastersController : Controller
    {
         

        private DatabaseContext db = new DatabaseContext();
        private readonly ICategoryMasters _categoryMasters;
        public CategoryMastersController()
        {
            this._categoryMasters = new CategoryMastersRepository();
        }
        // GET: CategoryMasters
        public ActionResult Index()
        {
            return View();
        }

        // GET: CategoryMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMaster.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryMasters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,CategoryName,WagesType,IntimeOutTimePunch,PresentHour,OTHour,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                categoryMaster.CategoryName = categoryMaster.CategoryName.ToUpper();
                categoryMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                categoryMaster.CreatedBy = Convert.ToInt64(Session["UserId"]);
                categoryMaster.CreatedAt = DateTime.Now;
                db.CategoryMaster.Add(categoryMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(categoryMaster);
        }

        // GET: CategoryMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMaster.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,CategoryName,WagesType,IntimeOutTimePunch,PresentHour,OTHour,ConCode,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt")] CategoryMaster categoryMaster)
        {
            if (ModelState.IsValid)
            {
                categoryMaster.CategoryName = categoryMaster.CategoryName.ToUpper();
                categoryMaster.ConCode = Convert.ToInt32(Session["ConCode"]);
                categoryMaster.UpdatedBy = Convert.ToInt64(Session["UserId"]);
                categoryMaster.UpdatedAt = DateTime.Now;
                db.Entry(categoryMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(categoryMaster);
        }

        // GET: CategoryMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoryMaster categoryMaster = await db.CategoryMaster.FindAsync(id);
            if (categoryMaster == null)
            {
                return HttpNotFound();
            }
            return View(categoryMaster);
        }

        // POST: CategoryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CategoryMaster categoryMaster = await db.CategoryMaster.FindAsync(id);
            db.CategoryMaster.Remove(categoryMaster);
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
            var categoryMasterViewModels = _categoryMasters.GetCategoryMasterDetails(); //This method is returning the IEnumerable employee from database 
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                categoryMasterViewModels = categoryMasterViewModels.Where(x => x.WagesType.ToLower().Contains(param.sSearch.ToLower())
                                              || x.Category.ToLower().Contains(param.sSearch.ToLower())).ToList();
            }
            var sortColumnIndex = Convert.ToInt32(HttpContext.Request.QueryString["iSortCol_0"]);
            var sortDirection = HttpContext.Request.QueryString["sSortDir_0"];
            if (sortColumnIndex == 3)
            {
                categoryMasterViewModels = sortDirection == "asc" ? categoryMasterViewModels.OrderBy(c => c.WagesType) : categoryMasterViewModels.OrderByDescending(c => c.WagesType);
            }
            else if (sortColumnIndex == 4)
            {
                categoryMasterViewModels = sortDirection == "asc" ? categoryMasterViewModels.OrderBy(c => c.Category) : categoryMasterViewModels.OrderByDescending(c => c.Category);
            }
            else
            {
                Func<CategoryMasterViewModel, string> orderingFunction = e => sortColumnIndex == 0 ? e.WagesType : sortColumnIndex == 1 ? e.Category : e.Category;
                categoryMasterViewModels = sortDirection == "asc" ? categoryMasterViewModels.OrderBy(orderingFunction) : categoryMasterViewModels.OrderByDescending(orderingFunction);
            }
            var displayResult = categoryMasterViewModels.Skip(param.iDisplayStart)
               .Take(param.iDisplayLength).OrderBy(x=>x.Id).ToList();
            var totalRecords = categoryMasterViewModels.Count();
            return Json(new { param.sEcho, iTotalRecords = totalRecords, iTotalDisplayRecords = totalRecords, aaData = displayResult }, JsonRequestBehavior.AllowGet);
        }

    }
}
