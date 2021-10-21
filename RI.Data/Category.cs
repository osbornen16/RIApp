using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Data
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey(nameof(Product))]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int Description { get; set; }
        
    }
}
