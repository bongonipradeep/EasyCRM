using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.Models.ViewModels
{
    public class EngineerVM
    {
        public int EngineerId { get; set; }
        [Required]
        public string EngineerName { get; set; }
        [Required]

        public string EngineerAddress { get; set; }

        public string EngineerPhone { get; set; }

        public string EngineerCity { get; set; }
        public string EngineerRegion { get; set; }
    }
}
