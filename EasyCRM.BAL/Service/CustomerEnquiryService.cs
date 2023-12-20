using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCRM.BAL.Interface;
using EasyCRM.Models.ViewModels;

namespace EasyCRM.BAL.Service
{
    public class CustomerEnquiryService : ICustomerEnquiryService
    {
        public Task<CustomerEnquiryVM> GetCustomerEnquiries()
        {
            throw new NotImplementedException();
        }
    }
}
