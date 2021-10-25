using RI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RI.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }

        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int ItemCount { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public decimal OrderTotal { get; set; }
  
        public Guid PersonId { get; set; }
        public virtual Person Person { get; set; }
    }
}