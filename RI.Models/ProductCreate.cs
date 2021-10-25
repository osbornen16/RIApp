using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Models
{
    public class ProductCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "Enter info please")]
        [MaxLength(100, ErrorMessage ="Not too much")]
        public string ProductName { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
