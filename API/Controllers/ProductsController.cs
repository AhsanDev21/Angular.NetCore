using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //we are using 'api/' because its conventional
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo; //StoreContext _context;
        public ProductsController (IProductRepository repo)//StoreContext context)// created construcor and injected StoreContext Database and we can use it. Its dependency injection and its very easy to use Database in our code by implementing DI
        {
            _repo = repo;
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync(); //_context.Products.ToListAsync();

            return Ok(products);
        }
        [HttpGet("{id}")] //we have made a route parameter here ("{id}")
        public async Task<ActionResult<Product>> GetProducts(int id)
        {
            return await _repo.GetProductByIdAsync (id);//_context.Products.FindAsync(id);
        }
    }
}