﻿using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataWebApiAspNetCore.Models;
using System;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        private readonly ODataDbContext _context;

        public EmployeesController(ODataDbContext context)
        {
            _context = context;
        }

        [ODataRoute("Employees")]
        [EnableQuery]
        //[QueryValidator1()]
        public IActionResult GetItems()
        {
            return GetAll(_context.Employee);
        }

        [ODataRoute("Employees({key})")]
        [EnableQuery]
        public IActionResult GetItem(Guid key)
        {
            return GetItem(_context.Employee, t => t.Id == key);
        }

        [ODataRoute("Employees")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employee obj)
        {
            obj.Id = Guid.NewGuid();
            return await PostItemAsync(obj, _context);
        }

        [ODataRoute("Employees({key})")]
        [HttpPatch]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Employee> obj)
        {
            return await PatchItemAsync(key, obj, _context.Employee, _context, t => t.Id == key);
        }

        [ODataRoute("Employees({key})")]
        [HttpPut]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Put([FromODataUri] Guid key, Employee obj)
        {
            return await PutItemAsync(obj, _context, t => t.Id == key, _context.Employee);
        }


        [ODataRoute("Employees({key})")]
        [HttpDelete]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            return await DeleteItemAsync(key, _context.Employee, _context);
        }
    }
}
