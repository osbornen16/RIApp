using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Models
{
    public class OrderCreate
    {
        [Required]
        public int ItemCount { get; set; }
        public decimal OrderTotal { get; set; }
    }
}
