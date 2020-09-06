using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSHRMS.Models;
using VSHRMS.Repository.Interface.MASTER;
using VSHRMS.ViewModels.MASTER;

namespace VSHRMS.Repository.Repository
{
    public class DesignationMastersRepository : IDesignationMasters
    {
        public DatabaseContext db = new DatabaseContext();
        public IEnumerable<DesignationMasterViewModel> GetDesignationMasterDetails()
        {
            var res = HttpContext.Current.Session["ConCode"];
            int conCode = Convert.ToInt32(res);
            var result = db.DesignationMaster.Where(x => x.ConCode == conCode).Select(x => new DesignationMasterViewModel()
            {
                Designation = x.DesignationName,                
                Id = x.id
            });
            return result;
        }

    }
}