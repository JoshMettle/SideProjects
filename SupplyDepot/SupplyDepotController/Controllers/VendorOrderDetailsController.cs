using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupplyDepotDomain.Model;

namespace SupplyDepotController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorOrderDetailsController : ControllerBase
    {
        private readonly SupplyOrdersContext _context;

        public VendorOrderDetailsController(SupplyOrdersContext context)
        {
            _context = context;
        }

        // GET: api/VendorOrderDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorOrderDetail>>> GetVendorOrderDetails()
        {
          if (_context.VendorOrderDetails == null)
          {
              return NotFound();
          }
            return await _context.VendorOrderDetails.ToListAsync();
        }

        // GET: api/VendorOrderDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorOrderDetail>> GetVendorOrderDetail(int id)
        {
          if (_context.VendorOrderDetails == null)
          {
              return NotFound();
          }
            var vendorOrderDetail = await _context.VendorOrderDetails.FindAsync(id);

            if (vendorOrderDetail == null)
            {
                return NotFound();
            }

            return vendorOrderDetail;
        }

        // PUT: api/VendorOrderDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorOrderDetail(int id, VendorOrderDetail vendorOrderDetail)
        {
            if (id != vendorOrderDetail.VendorOrderDetailId)
            {
                return BadRequest();
            }

            _context.Entry(vendorOrderDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorOrderDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VendorOrderDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorOrderDetail>> PostVendorOrderDetail(VendorOrderDetail vendorOrderDetail)
        {
          if (_context.VendorOrderDetails == null)
          {
              return Problem("Entity set 'SupplyOrdersContext.VendorOrderDetails'  is null.");
          }
            _context.VendorOrderDetails.Add(vendorOrderDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorOrderDetail", new { id = vendorOrderDetail.VendorOrderDetailId }, vendorOrderDetail);
        }

        // DELETE: api/VendorOrderDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorOrderDetail(int id)
        {
            if (_context.VendorOrderDetails == null)
            {
                return NotFound();
            }
            var vendorOrderDetail = await _context.VendorOrderDetails.FindAsync(id);
            if (vendorOrderDetail == null)
            {
                return NotFound();
            }

            _context.VendorOrderDetails.Remove(vendorOrderDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorOrderDetailExists(int id)
        {
            return (_context.VendorOrderDetails?.Any(e => e.VendorOrderDetailId == id)).GetValueOrDefault();
        }
    }
}
