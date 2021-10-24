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
    public class CategoryDetail
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
