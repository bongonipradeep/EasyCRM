using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class ProductReportVM
    {
        public string productName { get; set; }
        public string  companyName { get; set; }
        public string  customerName { get; set; }

        public string QueryDescription { get; set; }
    }
}   
