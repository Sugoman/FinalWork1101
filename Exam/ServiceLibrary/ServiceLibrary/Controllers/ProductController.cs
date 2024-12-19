using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;

namespace ApiFragrantWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly FragrantWorldContext _context;
        private static List<Product> Products = new List<Product>();
        public ProductController(FragrantWorldContext context)
        {
            _context = context;
            Products = _context.Products.ToList();
        }

        // GET: Products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAllProducts()
        {
            return Ok(Products);
        }

        // GET: api/Product/{id}
        [HttpGet("Product/{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(i => i.ProductId == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Product>> Create(Product newProduct)
        {
            try
            {
                _context.Products.Add(newProduct);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = newProduct.ProductId }, newProduct);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/Product/{id}
        [HttpPut("Product/{id}")]
        public IActionResult Update(int id, Product newProduct)
        {
            var product = Products.FirstOrDefault(i => i.ProductId == id);
            if (product == null)
                return NotFound();

            product.ProductArticleNumber = newProduct.ProductArticleNumber;
            product.ProductName = newProduct.ProductName;
            product.ProductDescription = newProduct.ProductDescription;
            product.ProductCategory = newProduct.ProductCategory;  
            product.ProductPhoto = newProduct.ProductPhoto; 
            product.ProductManufacturer = newProduct.ProductManufacturer;
            product.ProductCost = newProduct.ProductCost;
            product.ProductDiscountAmount = newProduct.ProductDiscountAmount;
            product.ProductQuantityInStock = newProduct.ProductQuantityInStock;
            product.ProductStatus = newProduct.ProductStatus;            
            
            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/PickupPoints/{article}
        [HttpDelete("Product/{article}")]
        public async Task<IActionResult> Delete(string article)
        {
            var products = Products.FirstOrDefault(i => i.ProductArticleNumber == article);
            if (products == null)
                return NotFound();

            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
