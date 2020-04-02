using Microsoft.AspNetCore.Mvc;
using ODataWebApiAspNetCore.Models;
using ODataWebApiAspNetCore.QueryValidators;
using System.Collections.Generic;

namespace ODataWebApiAspNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ODataDbContext _context;

        public EmployeeController(ODataDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        //[EnableQuery()]
        [QueryValidator1(MaxExpansionDepth = 10)]
        public IEnumerable<Employee> GetEmployyes()
        {
            return _context.Employee;
        }
    }
}
