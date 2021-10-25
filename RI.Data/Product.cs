using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Data
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Person))]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }

        public virtual Category Category { get; set; }
        [ForeignKey (nameof(Category))]
        public int CategoryId { get; set; }


        [Required]
        public int QuantityInStock { get; set; }
        public bool InStock
        {
            get
            {
                return QuantityInStock > 0;
            }
        }
        public bool LowStock { 
            get
            {
                return QuantityInStock < 5;
            }
                }

        //stretch - photos?
        //public int Photo { get; set; }
    }
}
