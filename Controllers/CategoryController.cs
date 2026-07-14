using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using MVCAPIs_Controller.Data;
using MVCAPIs_Controller.Model;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace MVCAPIs_Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDb db;

        public CategoryController(ApplicationDb db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            return await db.tblCategories.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}")] //api/category/1
        public async Task<ActionResult<Category>>? GetById(int id)
        {
            var category = await db.tblCategories.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
            if(category == null) return NotFound();
            else
                return Ok(category);
            
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create([FromForm]Category category)
        {
            try
            {
                db.tblCategories.Add(category);
                db.SaveChanges();

                return CreatedAtAction(nameof(GetById),new { id = category.Id }, category); // to return added cat
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured. Error Message: {ex.Message}");  
            }
        }


        [HttpPost]
        [Route("update/{id}")] //api/category/update/1
        public ActionResult UpdateCat(int id, Category category)
        {
            if (category.Id != id) return BadRequest("please check the id");

            try
            {
                db.tblCategories.Update(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured. Error Message: {ex.Message}");
            }

            return NoContent();
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult DeleteCat(int id)
        {
            var category = db.tblCategories.AsNoTracking().FirstOrDefault(c => c.Id == id);

            if (category == null) return NotFound();

            try
            {
                db.tblCategories.Remove(category);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest($"An error occured. Error Message: {ex.Message}");
            }

            return Ok(category);
        }

    }
}
