using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerDescription { get; set; }
        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerCity { get; set; }
        public string CustomerRegion { get; set; }
    }
}
