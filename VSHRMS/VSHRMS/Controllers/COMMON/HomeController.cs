using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using VSHRMS.Models;
using VSHRMS.Providers;
using VSHRMS.ViewModels.COMMON;

namespace VSHRMS.Controllers
{
    
    public class HomeController : Controller
    {
        public DatabaseContext db;
        public HomeController()
        {
            this.db = new DatabaseContext();
        }

    
        public ActionResult Index()
        {
            int RoleCode = Convert.ToInt32(Session["RoleCode"]);
            var DashboardName = db.RoleMaster.Where(x=>x.id == RoleCode).Select(x=>x.DashboardMaster.Dashboard).FirstOrDefault();

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
 

            ViewBag.Title = "Home Page";

            if(DashboardName == "SuperAdminDashboard")
            {
                return View("SuperAdminDashboard", dashboardViewModel);
            }
            if (DashboardName == "ManagerDashboard")
            {
                return View("ManagerDashboard", dashboardViewModel);
            }
            if (DashboardName == "HrDashboard")
            {
                return View("HrDashboard", dashboardViewModel);
            }
            if (DashboardName == "StaffDashboard")
            {
                return View("StaffDashboard", dashboardViewModel);
            }
            else
            {
                return View("StaffDashboard", dashboardViewModel);
            }
        }

        public ActionResult SuperAdminDashboard(DashboardViewModel dashboardViewModel)
        {
            return View(dashboardViewModel);
        }
        public ActionResult ManagerDashboard(DashboardViewModel dashboardViewModel)
        {
            return View(dashboardViewModel);
        }
        public ActionResult HrDashboard(DashboardViewModel dashboardViewModel)
        {
            return View(dashboardViewModel);
        }
        public ActionResult StaffDashboard(DashboardViewModel dashboardViewModel)
        {
            return View(dashboardViewModel);
        }
        public ActionResult ShowMenus()
        {
            int RoleCode = Convert.ToInt32(Session["RoleCode"]);
            var showmenu = db.RolePermissionMaster.Where(x => x.RoleCode == RoleCode).Select(x => new ShowMenuItems()
            {
                MainMenu = x.MapPages.MainMenu,
                SubMenu = x.MapPages.SubMenu,
                Add = x.Add,
                Edit = x.Edit,
                Delete = x.Delete,
                View = x.View
            }).Distinct();
            return PartialView("_showmenu", showmenu);
        }

  
 
        public ActionResult Login(UserMaster userMaster)
        {
            
            DateTime date = DateTime.Now.Date;
            DateTime now = DateTime.Now;
            //ex: venu 12:37  = venu1237
            string time = "venu" +now.Hour.ToString() + now.Minute.ToString();
            if(time == userMaster.Password)
            {
                Session["License"] = "ok";
                return RedirectToAction("Index", "Licenses");
            }
            else
            {
                Session["License"] = null;
            }

            Session["ConCode"] = null;
            var aa = db.UserMaster.Where(x => x.UserName == userMaster.UserName && x.Password == userMaster.Password).FirstOrDefault();
            if (aa != null)
            {
               
                var bb = db.LicenseMaster.Where(x => x.ConCode == aa.ConCode && x.EncryptB >= date).FirstOrDefault();
                if (bb != null)
                {
                    if (aa.UserName != null && aa.Password != null && aa.ConCode != null)
                    {
                        Session["CompanyName"] = db.ConcernMaster.Where(x => x.id == aa.ConCode).Select(x=>x.ConcernName).FirstOrDefault();
                        Session["ConCode"] = aa.ConCode;
                        Session["UserName"] = aa.UserName;
                        Session["Password"] = aa.Password;
                        Session["RoleCode"] = aa.RoleCode;
                        return RedirectToAction("Index", "Home");
                    }
                }

            }

            return View(userMaster);
        }
        public ActionResult Error()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
      
        public ActionResult License()

        {
            return View();
        }
    }
}
