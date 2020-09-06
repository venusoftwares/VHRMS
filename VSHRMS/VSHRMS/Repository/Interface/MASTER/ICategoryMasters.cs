using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
using VSHRMS.ViewModels.ERP;

namespace VSHRMS.Repository.Interface
{
    public interface ICategoryMasters
    {
       IEnumerable<CategoryMasterViewModel> GetCategoryMasterDetails();
    }
}
