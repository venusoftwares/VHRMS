using System;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Routing; 


using System.Data.Entity;
using VSHRMS.Models;

namespace VSHRMS.Providers
{
    public class AuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;
            DatabaseContext db = new DatabaseContext();
            int RoleCode = Convert.ToInt32(session["RoleCode"]);
            try
            {
                var ControllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;  
                var chech = db.RolePermissionMaster.Include(p => p.MapPages).Any(x=>x.MapPages.ControllerName  == ControllerName && x.RoleCode == RoleCode && (
                x.Add == true ||
                x.Edit == true ||
                x.Delete == true ||
                x.View == true));
                if (controller != null)
                {
                    if (session["ConCode"] == null)
                    {                        
                        controller.HttpContext.Response.Redirect("/Home/Login");
                    }
                    if(!chech)
                    {
                        controller.HttpContext.Response.Redirect("/Home/Login");
                    }
                }
                base.OnActionExecuting(filterContext);
               
            }
            catch
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        private bool Authenticated(HttpRequestBase httpRequestBase)
        {
            bool authenticated = false;
            return authenticated;
        }
    }
}