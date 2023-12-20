using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCRM.DAL.Entity.DataModel
{
    [Table("Product")]
    public class Product
    {
        public Product()
        {
            this.CustomerEnquiries = new HashSet<CustomerEnquiry>();
        }
        [Key] // Primary Key
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; } = 0;

        public virtual ICollection<CustomerEnquiry> CustomerEnquiries { get; set; }
    }
}
