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
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Products
                    .Where(e => e.PersonId == _userId)
                    .Select(
                        e =>
                        new ProductList
                        {
                            Id = e.Id,
                            ProductName = e.ProductName
                        }
                        );
                return query.ToArray();
            }

        }

        public ProductDetails GetProductById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.PersonId == _userId && e.Id == id);
                return
                    new ProductDetails
                    {
                        Id = entity.Id,
                        ProductName = entity.ProductName,
                        Price = entity.Price,
                        Description = entity.Description
                    };

            }


        }

        public bool UpdateProduct(ProductEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.PersonId == _userId && e.Id == model.Id);
                entity.ProductName = model.ProductName;
                entity.Price = model.Price;
                entity.QuantityInStock = model.QuantityInStock;
                entity.Description = model.Description;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteProduct(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Products
                    .Single(e => e.PersonId == _userId && e.Id == id);
                ctx.Products.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
