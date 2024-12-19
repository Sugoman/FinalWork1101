using Library.Data;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class PickupPointService
    {
        private readonly FragrantWorldContext _context;

        public PickupPointService(FragrantWorldContext context)
        {
            _context = context;
        }

        public async Task<List<PickupPoint>> GetAllPickupPointsAsync()
        {
            return await _context.PickupPoints.ToListAsync();
        }

        public async Task<PickupPoint> GetPickupPointByIdAsync(int id)
        {
            return await _context.PickupPoints.FindAsync(id);
        }
    }
}
