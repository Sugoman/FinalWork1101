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
    public class OrderController : ControllerBase
    {
        private readonly FragrantWorldContext _context;
        private static List<Order> Orders = new List<Order>(); 
        public OrderController(FragrantWorldContext context)
        {
            _context = context;
            Orders = _context.Orders.ToList();
        }

        // GET: Order
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return Ok(Orders);
        }

        // GET: api/Order/{id}
        [HttpGet("{id}")]
        public ActionResult<Order> GetById(int id)
        {
            var order = Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        // POST: api/Orders
        [HttpPost]
        public async Task<ActionResult<Order>> Create(Order newOrder)
        {
            try
            {
                _context.Orders.Add(newOrder);
                await _context.SaveChangesAsync(); 
                return CreatedAtAction(nameof(GetById), new { id = newOrder.OrderId }, newOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/Order/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, Order updatedOrder)
        {
            var order = Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null)
                return NotFound();

            order.OrderComposition = updatedOrder.OrderComposition;
            order.OrderCount = updatedOrder.OrderCount;
            order.OrderDate = updatedOrder.OrderDate;
            order.OrderDeliveryDate = updatedOrder.OrderDeliveryDate;
            order.OrderPickupPoint = updatedOrder.OrderPickupPoint;
            order.OrderClientFirstName = updatedOrder.OrderClientFirstName;
            order.OrderClientSurname = updatedOrder.OrderClientSurname;
            order.OrderClientPatronymic = updatedOrder.OrderClientPatronymic;
            order.OrderCode= updatedOrder.OrderCode;
            order.OrderStatus = updatedOrder.OrderStatus;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = Orders.FirstOrDefault(i => i.OrderId == id);
            if (order == null)
                return NotFound();

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
