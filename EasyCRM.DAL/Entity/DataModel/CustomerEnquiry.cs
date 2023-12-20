using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Entity.DataModel
{
    [Table("CustomerEnquiry")]
    public class CustomerEnquiry
    {
        [Key]
        public int CustomerEnquiryID { get; set; }
        public string QueryDescription { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int CompanyId { get; set; }
        public virtual Customer Customer { get; set; }
        public  virtual Product Product { get; set; }

        public virtual Company Company { get; set; }
    }
}
