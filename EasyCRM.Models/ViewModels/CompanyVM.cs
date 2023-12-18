using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class CompanyVM
    {
        public int? CompanyId { get; set; }
        [Required(ErrorMessage = "ComanyName")]
        public string CompanyName { get; set; }
        [Required]
        public string CompanyDescription { get; set; }
        public string? CompanyAddress { get; set; }

        public string CompanyPhone { get; set; }
    }
}
