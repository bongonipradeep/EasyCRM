using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class CustomerEnquiryVM
    {
        public int? CustomerEnquiryID { get; set; }
        public string QueryDescription { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        public CustomerVM customer { get; set; }

        public ProductVM product { get; set; }

        public CompanyVM company { get; set; }
    }
}
