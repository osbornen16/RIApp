using RI.Data;
using RI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RI.Service
{
    public class ProductService
    {
        private readonly Guid _userId;

        public ProductService(Guid userId)
        { _userId = userId; }

        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    ProductName = model.ProductName,
                    Price = model.Price,
                    Description = model.Description
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProductList> GetProducts()
        {
            using( var ctx = new ApplicationDbContext())
            {
                var query = 
                    ctx.Products.Where( e=> e.Id == _userId)
                    .Se
            }

        }

        public ProductDetails GetProductById(int id)
        {

        }

        public bool UpdateProduct(ProductEdit model)
        {

        }

        public bool DeleteProduct(int id)
        {

        }
    }
}
