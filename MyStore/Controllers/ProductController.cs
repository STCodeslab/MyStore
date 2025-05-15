using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Repository;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProducts _productRepository;
        public ProductController(IProducts product)
        {
            _productRepository = product;

        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

           var created = await _productRepository.CreateAsync(product);

            return CreatedAtAction(nameof(GetByID),new { id = created.ProductId }, created);
        }

        [HttpPut]
        [Route("update/{id}")]

        public async Task<IActionResult> update(int id ,[FromBody] Product product){
            if (id != product.ProductId) return BadRequest("ID not match");

            var exist = await _productRepository.GetByIdAsync(id);
            if (exist == null) return NotFound();

            var update = await _productRepository.UpdateAsync(product);

            return Ok(update);
}


        [HttpDelete]
        [Route("delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var exist = await _productRepository.GetByIdAsync(id);

            if (exist == null) return NotFound();

            await _productRepository.DeleteAsync(exist);

            return NoContent();



        }

        [HttpGet]
        [Route("All")]

        public async Task<IActionResult> GetAllProducts()
        {
            var products= await _productRepository.GetAllAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("GetByID")]

        public async Task<IActionResult> GetByID(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
