using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using VSHRMS.Models;
using VSHRMS.Repository.Interface;
using VSHRMS.ViewModels.ERP;

namespace VSHRMS.Repository.Repository
{
    public class CategoryMastersRepository : ICategoryMasters
    {
        public DatabaseContext db = new DatabaseContext();
        public IEnumerable<CategoryMasterViewModel> GetCategoryMasterDetails()
        {
            var res = HttpContext.Current.Session["ConCode"];
            int conCode = Convert.ToInt32(res);
            var result = db.CategoryMaster.Where(x=>x.ConCode == conCode).Select(x => new CategoryMasterViewModel()
            {                
                WagesType = x.WagesType,
                Category = x.CategoryName,
                Id = x.id
            });
            return result;
        }


    }
}
