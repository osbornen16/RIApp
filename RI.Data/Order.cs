using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Data
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Person))]
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }

        [ForeignKey(nameof(Product))]
        public string ProductId { get; set; }
        public virtual Product Product { get; set; }

        [Required]
        public int ItemCount { get; set; }

        [Required]
        public DateTimeOffset OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
