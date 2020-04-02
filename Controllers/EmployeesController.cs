using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ODataWebApiAspNetCore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class EmployeesController : ODataController
    {
        private readonly ODataDbContext _context;

        public EmployeesController(ODataDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        [EnableQuery]
        //[QueryValidator1()]
        public IActionResult GetEmployees()
        {
            return Ok(_context.Employee);
        }

        //[HttpGet]
        [EnableQuery]
        //[QueryValidator1()]
        public IActionResult GetEmployee(Guid key)
        {
            return Ok(_context.Employee.Where(t => t.Id == key));
        }

        public async Task<IActionResult> Post([FromBody] Employee e)
        {
            e.Id = Guid.NewGuid();
            _context.Employee.Add(e);
            await _context.SaveChangesAsync();
            return Created(e);
        }

        [ODataRoute()]
        [HttpPatch]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Employee> employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await _context.Employee.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            employee.Patch(entity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExist(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(entity);
        }

        [ODataRoute()]
        [HttpPut]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Put([FromODataUri] System.Guid key, Employee update)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!EmployeeExist(key))
            {
                return BadRequest();
            }
            _context.Entry(update).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExist(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Updated(update);
        }


        [ODataRoute()]
        [HttpDelete]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            var appVersions = await _context.Employee.FindAsync(key);
            if (appVersions == null)
            {
                return NotFound();
            }
            _context.Employee.Remove(appVersions);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool EmployeeExist(Guid key)
        {
            return _context.Employee.Any(p => p.Id == key);
        }

    }
}
