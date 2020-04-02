using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataWebApiAspNetCore.Models;
using System;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    public class CompanyController : BaseController<Company>
    {
        private readonly ODataDbContext _context;

        public CompanyController(ODataDbContext context)
        {
            _context = context;
        }

        [ODataRoute("Companies")]
        [EnableQuery]
        //[QueryValidator1()]
        public IActionResult GetItems()
        {
            return GetAll(_context.Company);
        }

        [ODataRoute("Companies({key})")]
        [EnableQuery]
        public IActionResult GetItem(Guid key)
        {
            return GetItem(_context.Company, t => t.Id == key);
        }

        [ODataRoute("Companies")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Company obj)
        {
            obj.Id = Guid.NewGuid();
            return await PostItemAsync(obj, _context);
        }

        [ODataRoute("Companies({key})")]
        [HttpPatch]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Company> obj)
        {
            return await PatchItemAsync(key, obj, _context.Company, _context, t => t.Id == key);
        }

        [ODataRoute("Companies({key})")]
        [HttpPut]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Put([FromODataUri] Guid key, Company obj)
        {
            return await PutItemAsync(obj, _context, t => t.Id == key, _context.Company);
        }


        [ODataRoute("Companies({key})")]
        [HttpDelete]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            return await DeleteItemAsync(key, _context.Company, _context);
        }
    }
}
