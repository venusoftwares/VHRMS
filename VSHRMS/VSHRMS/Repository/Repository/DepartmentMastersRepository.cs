using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSHRMS.Models;
using VSHRMS.Repository.Interface.MASTER;
using VSHRMS.ViewModels.MASTER;

namespace VSHRMS.Repository.Repository
{
    public class DepartmentMastersRepository : IDepartmentMasters
    {
        public DatabaseContext db = new DatabaseContext();
        public IEnumerable<DepartmentMasterViewModel> GetDepartmentMasterDetails()
        {
            var res = HttpContext.Current.Session["ConCode"];
            int conCode = Convert.ToInt32(res);
            var result = db.DepartmentMaster.Where(x => x.ConCode == conCode).Select(x => new DepartmentMasterViewModel()
            {
                Department = x.DepartmentName,                
                Id = x.id
            });
            return result;
        }

    }
}