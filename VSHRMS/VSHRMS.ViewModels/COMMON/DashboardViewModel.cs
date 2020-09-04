using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSHRMS.ViewModels.COMMON
{
    public class DashboardViewModel
    {
        public int TotalBrands { get; set; }
        public int TotalCategories { get; set; }
        public int TotalItems { get; set; }
        public int TotalCustomers { get; set; }
        public int TotalSuppliers { get; set; }
        public int TotalQuotation { get; set; }
        public int TotalSales { get; set; }
        public int TotalPurchase { get; set; }

      


        public decimal? TodayTotalQuotationAmount { get; set; }
        public decimal? TodayTotalSalesAmount { get; set; }
        public decimal? TodayTotalPurchases { get; set; }

        public decimal? TotalCashReceived { get; set; }
        public decimal? TotalCashPayment { get; set; }


    }
    public class ShowMenuItems
    {
        public string MainMenu { get; set; }
        public string SubMenu { get; set; }
        public bool Add { get; set; }
        public bool Edit { get; set; }
        public bool View { get; set; }
        public bool Delete { get; set; }
    }
}
