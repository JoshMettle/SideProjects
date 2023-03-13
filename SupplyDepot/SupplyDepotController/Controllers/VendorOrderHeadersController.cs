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
    public class VendorOrderHeadersController : ControllerBase
    {
        private readonly SupplyOrdersContext _context;

        public VendorOrderHeadersController(SupplyOrdersContext context)
        {
            _context = context;
        }

        // GET: api/VendorOrderHeaders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorOrderHeader>>> GetVendorOrderHeaders()
        {
          if (_context.VendorOrderHeaders == null)
          {
              return NotFound();
          }
            return await _context.VendorOrderHeaders.ToListAsync();
        }

        // GET: api/VendorOrderHeaders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VendorOrderHeader>> GetVendorOrderHeader(int id)
        {
          if (_context.VendorOrderHeaders == null)
          {
              return NotFound();
          }
            var vendorOrderHeader = await _context.VendorOrderHeaders.FindAsync(id);

            if (vendorOrderHeader == null)
            {
                return NotFound();
            }

            return vendorOrderHeader;
        }

        // PUT: api/VendorOrderHeaders/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendorOrderHeader(int id, VendorOrderHeader vendorOrderHeader)
        {
            if (id != vendorOrderHeader.VendorOrderId)
            {
                return BadRequest();
            }

            _context.Entry(vendorOrderHeader).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorOrderHeaderExists(id))
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

        // POST: api/VendorOrderHeaders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VendorOrderHeader>> PostVendorOrderHeader(VendorOrderHeader vendorOrderHeader)
        {
          if (_context.VendorOrderHeaders == null)
          {
              return Problem("Entity set 'SupplyOrdersContext.VendorOrderHeaders'  is null.");
          }
            _context.VendorOrderHeaders.Add(vendorOrderHeader);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendorOrderHeader", new { id = vendorOrderHeader.VendorOrderId }, vendorOrderHeader);
        }

        // DELETE: api/VendorOrderHeaders/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorOrderHeader(int id)
        {
            if (_context.VendorOrderHeaders == null)
            {
                return NotFound();
            }
            var vendorOrderHeader = await _context.VendorOrderHeaders.FindAsync(id);
            if (vendorOrderHeader == null)
            {
                return NotFound();
            }

            _context.VendorOrderHeaders.Remove(vendorOrderHeader);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorOrderHeaderExists(int id)
        {
            return (_context.VendorOrderHeaders?.Any(e => e.VendorOrderId == id)).GetValueOrDefault();
        }
    }
}
