using Application.Commands.Products;
using Application.Interfaces;
using Application.Queryies.Products;
using Core.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly ISender _sender;
        public ProductController(ISender sender)
        {
            _sender = sender;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _sender.Send(new GetAllProductsQuery());
            return Ok(response);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var Product = await _sender.Send(new GetProductByIdQuery(id));
            return Product != null ? Ok(Product) : NotFound();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto ProductDto)
        {
            var response = await _sender.Send(new CreateProductCommand(ProductDto));
            return CreatedAtRoute("GetProductById", new { id = response.Id }, response);
        }
        [HttpPut("Update")]
        public async Task<IActionResult> UpdateProduct(ProductDto ProductDto)
        {
            var response = await _sender.Send(new UpdateProductCommand(ProductDto));
            return response ? Ok() : BadRequest(ProductDto);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteProduct(ProductDto ProductDto)
        {
            var response = await _sender.Send(new DeleteOneProductCommand(ProductDto));
            return response ? Ok() : BadRequest(ProductDto);
        }
    }
}
