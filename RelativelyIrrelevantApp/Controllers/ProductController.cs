using Microsoft.AspNet.Identity;
using RI.Models;
using RI.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RelativelyIrrelevantApp.Controllers
{
    public class ProductController : ApiController
    {
        private ProductService CreateProductService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var productService = new ProductService(userId);
            return productService;
        }

        public IHttpActionResult Get()
        {
            ProductService productService = CreateProductService();
            var products = productService.GetProducts();
            return Ok(products);
        }

        public IHttpActionResult Post(ProductCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateProductService();
            if (!service.CreateProduct(model))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Get(int iD)
        {
            ProductService noteService = CreateProductService();
            var note = noteService.GetProductById(iD);
            return Ok(note);
        }

        public IHttpActionResult Put(ProductEdit product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProductService();
            if (!service.UpdateProduct(product))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProductService();
            if (!service.DeleteProduct(id))
                return InternalServerError();
            return Ok();
        }
    }
}
