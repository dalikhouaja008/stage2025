using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using shopping.API.Data;
using shopping.API.Models;

namespace shopping.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductController
    {
        private readonly ProductContext _context;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductContext context,ILogger<ProductController> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            _logger = logger?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<IEnumerable<product>> GetProductsAsync()
        {
                return await _context.Products.
                    Find(p => true).
                    ToListAsync();

        }
    }
}
