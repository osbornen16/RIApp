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
    public class CategoryController : ApiController
    {
        private CategoryService CreateCategoryService()
        {
            var CategoryService = new CategoryService();
            return CategoryService;
        }
        public IHttpActionResult Get()
        {
            CategoryService categoryService = CreateCategoryService();
            var categories = categoryService.GetCategories();
            return Ok(categories);
        }
        public IHttpActionResult Post(CategoryCreate note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.CreateNote(note))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Get(int id)
        {
            CategoryService noteService = CreateCategoryService();
            var note = noteService.GetCategoryById(id);
            return Ok(note);
        }
        public IHttpActionResult Put(CategoryEdit note)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var service = CreateCategoryService();
            if (!service.UpdateCategory(note))
                return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            var service = CreateCategoryService();
            if (!service.DeleteCategory(id))
                return InternalServerError();
            return Ok();
        }
    }
}
