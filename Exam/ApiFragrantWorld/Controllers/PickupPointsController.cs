using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Library.Data;
using Library.Models;
using NuGet.Packaging;

namespace ApiFragrantWorld.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupPointsController : ControllerBase
    {
        private readonly FragrantWorldContext _context;
        private static List<PickupPoint> PickupPoints = new List<PickupPoint>();
        public PickupPointsController(FragrantWorldContext context)
        {
            _context = context;
            PickupPoints = _context.PickupPoints.ToList();
        }

        // GET: PickupPoints
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return Ok(PickupPoints);
        }

        // GET: api/PickupPoint/{id}
        [HttpGet("{id}")]
        public ActionResult<PickupPoint> GetById(int id)
        {
            var user = PickupPoints.FirstOrDefault(i => i.PickupPointId == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        // POST: api/PickupPoints
        [HttpPost]
        public async Task<ActionResult<PickupPoint>> Create(PickupPoint newPickupPoint)
        {
            try
            {
                _context.PickupPoints.Add(newPickupPoint);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = newPickupPoint.PickupPointId }, newPickupPoint);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }

        // PUT: api/PickupPoint/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, PickupPoint newPickupPoint)
        {
            var pickupPoint = PickupPoints.FirstOrDefault(i => i.PickupPointId == id);
            if (pickupPoint == null)
                return NotFound();

            pickupPoint.PickupPointIndex = newPickupPoint.PickupPointIndex;
            pickupPoint.PickupPointCity = newPickupPoint.PickupPointCity;
            pickupPoint.PickupPointStreet = newPickupPoint.PickupPointStreet;
            pickupPoint.PickupPointHouse = newPickupPoint.PickupPointHouse;

            _context.SaveChanges();
            return NoContent();
        }

        // DELETE: api/PickupPoints/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pickupPoints = PickupPoints.FirstOrDefault(i => i.PickupPointId == id);
            if (pickupPoints == null)
                return NotFound();

            _context.PickupPoints.Remove(pickupPoints);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool PickupPointExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
