using Microsoft.AspNetCore.Mvc;
using OnlineShopMicroServices.ProductService.WebApi.Dtos.ProductDtos;
using OnlineShopMicroServices.ProductService.WebApi.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;
using OnlineShopMicroServices.ProductService.WebApi.Exceptions;

namespace OnlineShopMicroServices.ProductService.WebApi.Controllers
{
    [ApiController]
    [Route("Product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IAppDbContext _context;

        public ProductController(IProductManager productManager,
            IAppDbContext context)
        {
            this._productManager = productManager;
            this._context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductCreateDto createDto)
        {
            var product = await _productManager.CreateProductAsync(createDto.Name);
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            var readDto = product.Adapt<ProductReadDto>();

            return CreatedAtAction("GetById", new { Id = product.Id }, readDto);
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productDtos = await _context.Products
                .Select(s => new ProductReadDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .ToListAsync();

            return Ok(productDtos);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetById(long id)
        {
            var productDto = await _context.Products
                .Where(w => w.Id == id)
                .Select(s => new ProductReadDto()
                {
                    Id = s.Id,
                    Name = s.Name,
                })
                .FirstOrDefaultAsync();
            if (productDto == null)
                throw new NotFoundException("Product");

            return Ok(productDto);
        }
        [HttpPut]
        public async Task<IActionResult> Put(long id,ProductUpdateDto updateDto)
        {
            var product = await _context.Products
                .Where(w => w.Id == id)
                .FirstOrDefaultAsync();

            if(product== null)
                throw new NotFoundException($"Product");

            await _productManager.ChangeNameAsync(product, updateDto.Name);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
