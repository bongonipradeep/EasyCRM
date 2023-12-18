using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class StaffVM
    {
        public int StaffId { get; set; }
        [Required]
        public string StaffName { get; set; }
        [Required]

        public string StaffAddress { get; set; }

        public string StaffPhone { get; set; }

        public string StaffCity { get; set; }
        public string StaffRegion { get; set; }
    }
}
