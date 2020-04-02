using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataWebApiAspNetCore.Models;
using System;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    public class PracticeController : BaseController<Practice>
    {
        private readonly ODataDbContext _context;

        public PracticeController(ODataDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute("Practices")]
        //[QueryValidator1()]
        public IActionResult GetItems()
        {
            return GetAll(_context.Practice);
        }

        [EnableQuery]
        [ODataRoute("Practices({key})")]
        public IActionResult GetItem(Guid key)
        {
            return GetItem(_context.Practice, t => t.Id == key);
        }

        [ODataRoute("Practices")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Practice obj)
        {
            obj.Id = Guid.NewGuid();
            return await PostItemAsync(obj, _context);
        }

        [ODataRoute("Practices({key})")]
        [HttpPatch]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Practice> obj)
        {
            return await PatchItemAsync(key, obj, _context.Practice, _context, t => t.Id == key);
        }

        [ODataRoute("Practices({key})")]
        [HttpPut]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Put([FromODataUri] Guid key, Practice obj)
        {
            return await PutItemAsync(obj, _context, t => t.Id == key, _context.Practice);
        }


        [ODataRoute("Practices({key})")]
        [HttpDelete]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            return await DeleteItemAsync(key, _context.Practice, _context);
        }
    }
}
