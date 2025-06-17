using Microsoft.AspNetCore.Mvc;
using nguyenminhthien_5361.Models;
using nguyenminhthien_5361.Repositories;

[ApiController]
[Route("api/products")]
    public class ProductApiController : ControllerBase
    {
    private readonly IProductRepository _productRepository;
    public ProductApiController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    [HttpGet]
    public async Task<IActionResult> GetProducts()
    {
        try
        {
            var products = await _productRepository.GetAllAsync();
            return Ok(products);
        }
        catch (Exception ex)
        {
            // Handle exception
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
        catch (Exception ex)
        {
            // Handle exception
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
        try
        {
            await _productRepository.AddAsync(product);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
        catch (Exception ex)
        {
            // Handle exception
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        try
        {
            if (id != product.Id)
                return BadRequest();
            await _productRepository.UpdateAsync(product);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Handle exception
            return StatusCode(500, "Internal server error");
        }
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            await _productRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            // Handle exception
            return StatusCode(500, "Internal server error");
        }
    }
}
 