using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using melodeon_api_v2.Models;
using System.Data;

namespace melodeon_api_v2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceStatusController : ControllerBase
    {
        private readonly CerysContext _context;

        public ServiceStatusController(CerysContext context)
        {
            _context = context;
        }

        // GET: api/ServiceStatus
        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            using var command = _context.Database.GetDbConnection().CreateCommand();
            command.CommandText = "ss_get_service_status";
            command.CommandType = CommandType.StoredProcedure;
            await _context.Database.OpenConnectionAsync();
            using var result = command.ExecuteReader();
            if (result.HasRows)
            {
                result.Read();
                var x = result.GetString(0);
                return Ok(x);
            }
            return BadRequest("No data");
        }

        // GET: api/ServiceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceStatus>> GetServiceStatus(int id)
        {
            var serviceStatus = await _context.ServiceStatuses.FindAsync(id);

            if (serviceStatus == null)
            {
                return NotFound();
            }

            return serviceStatus;
        }

        // PUT: api/ServiceStatus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceStatus(int id, ServiceStatus serviceStatus)
        {
            if (id != serviceStatus.ServiceStatusId)
            {
                return BadRequest();
            }

            _context.Entry(serviceStatus).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceStatusExists(id))
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

        // POST: api/ServiceStatus
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ServiceStatus>> PostServiceStatus(ServiceStatus serviceStatus)
        {
            _context.ServiceStatuses.Add(serviceStatus);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceStatus", new { id = serviceStatus.ServiceStatusId }, serviceStatus);
        }

        // DELETE: api/ServiceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceStatus(int id)
        {
            var serviceStatus = await _context.ServiceStatuses.FindAsync(id);
            if (serviceStatus == null)
            {
                return NotFound();
            }

            _context.ServiceStatuses.Remove(serviceStatus);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ServiceStatusExists(int id)
        {
            return _context.ServiceStatuses.Any(e => e.ServiceStatusId == id);
        }
    }
}
