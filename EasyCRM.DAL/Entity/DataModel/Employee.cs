using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Entity.DataModel
{
    [Table("Employee")]
    public class Employee
    {
        [Key] // Primary Key
        public int EmployeeId { get; set; }
        [Required]
        public string EmployeeName { get; set; }
        [Required]
        public string EmployeeAddress { get; set; }
        public string EmployeePhone { get; set; }
        public string EmployeeCity { get; set; }
        public string? EmployeeRegion { get; set; }
        public string EmployeeType { get; set; } = string.Empty;

    }
}
