using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVCAPIs_Controller.Model;
using MVCAPIs_Controller.Services;

namespace MVCAPIs_Controller.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<Product>>> GetAll()
        {
            List<Product> list = await _productService.GetProducts();

            if (list == null || list.Count == 0)
                return NotFound();

            return Ok(list);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdProduct(int id)
        {
            var product = await _productService.GetProductById(id);

            if (product == null) return NotFound();

            else return Ok(product);
        }


        [HttpGet("byCategory/{id}")]
        public async Task<ActionResult<List<Product>>> GetByCategoryId(int id)
        {
            List<Product> list = await _productService.GetProductByCatId(id);

            if (list == null || list.Count == 0)
                return NotFound();

            return Ok(list);

        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<Product>> CreateProduct([FromForm]Product product)
        {
            var prod = await _productService.AddProduct(product);

            if (prod == null)
                return StatusCode(StatusCodes.Status500InternalServerError, $"The Product {product.Name} could Not be added ");

            else
            {
                //cerillization 
                product.Category.Products = null;
                return CreatedAtAction(nameof(GetByIdProduct), new { id = product.Id }, product);
            }




        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromForm] Product product)
        {

            if (id != product.Id)
                return BadRequest();

            var p = await _productService.UpdateProduct(product);

            if (p == null)
                return StatusCode(StatusCodes.Status500InternalServerError, $"The Product {product.Name} could Not be updated ");
            else
                return Ok(p);
        }


        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromForm]Product product)
        {
            (bool status, string msg) = await _productService.DeleteProduct(product);

            if (status == false)
                return StatusCode(StatusCodes.Status500InternalServerError, msg);
            else
                return Ok(msg);


        }




    }
}
