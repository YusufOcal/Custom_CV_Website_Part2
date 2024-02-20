using Custom_CV_Website__API.DAL.ApiContext;
using Custom_CV_Website__API.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Custom_CV_Website__API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
            using var c = new Context();
            return Ok(c.Categories.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id) 
        {
            using var c = new Context();
            var value = c.Categories.Find(id);
            if(value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category category)
        {
            using var c = new Context();
            c.Add(category);
            c.SaveChanges();
            return Created("", category);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            using var c = new Context();
            var bul = c.Categories.Find(id);
            if(bul == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(bul);
                c.SaveChanges();
                return NoContent();
            } 
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            using var c = new Context();
            var bul = c.Find<Category>(category.CategoryID);
            if(bul == null)
            {
                return NotFound();
            }
            else
            {
                bul.CategoryName = category.CategoryName;
                c.Update(bul);
                c.SaveChanges();
                return Created("", category);
            }
        }
    }
}
