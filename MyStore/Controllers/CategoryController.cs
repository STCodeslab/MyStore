using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Models;
using MyStore.Repository;

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly Icategory _categoryRepository;
        public CategoryController(Icategory icategory)
        {
            _categoryRepository = icategory;
            
        }

        [HttpPost("Add")]

        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);
            var created = await _categoryRepository.CreateAsync(category);
            return CreatedAtAction(nameof(GetById), new { id = created.CategoryId }, created);

        }

        [HttpGet("All")]
        public async Task<IActionResult> GetlAll()
        {
            var category = await _categoryRepository.GetAllAsync();
            return Ok(category);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return Ok(category);
        }

        [HttpDelete("delete/{id}")]

        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) return NotFound();

            await _categoryRepository.DeleteAsync(category);
            return NoContent();
        }


        [HttpPut]
        [Route("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Category category)
        {
            if (id != category.CategoryId) return BadRequest("mis match");

            var exist = _categoryRepository.GetByIdAsync(id);
            if (exist == null) return NotFound();

            var updated = await _categoryRepository.UpdateAsync(category);

            return Ok(updated);
                    
        }
    }
}
