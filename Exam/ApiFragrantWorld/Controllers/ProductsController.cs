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
    public class ProductsController : Controller
    {
        private readonly FragrantWorldContext _context;
        private static List<Product> Products = new List<Product>();
        public ProductsController(FragrantWorldContext context)
        {
            _context = context;
            Products = _context.Products.ToList();
        }

       

        // GET: api/Product/{article}
        [HttpGet("{article}")]
        public ActionResult<Product> GetByArticle(string article)
        {
            var product = Products.FirstOrDefault(i => i.ProductArticleNumber == article);
            if (product == null)
                return NotFound();
            return Ok(product);
        }
     
        // PUT: api/PickupPoint/{article}
        [HttpPut("{article}")]
        public IActionResult Update(string article, Product newProduct)
        {
            var product = Products.FirstOrDefault(i => i.ProductArticleNumber == article);
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
        [HttpDelete("{article}")]
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
