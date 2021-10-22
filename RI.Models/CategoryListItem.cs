using RI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Models
{
    public class CategoryListItem
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [ForeignKey(nameof(Product))]
        public int Id { get; set; }
        [ForeignKey(nameof(Product))]
        public int Description { get; set; }
        public virtual Product Product { get; set; }
    }
}
