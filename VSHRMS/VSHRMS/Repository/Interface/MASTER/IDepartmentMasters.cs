using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VSHRMS.ViewModels.MASTER;

namespace VSHRMS.Repository.Interface.MASTER
{
    public interface IDepartmentMasters
    {
        IEnumerable<DepartmentMasterViewModel> GetDepartmentMasterDetails();
    }
}