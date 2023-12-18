using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class EmployeeVM
    {
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeRegion { get; set; }
        public string EmployeeType { get; set; }
    }
}
