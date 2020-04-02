using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataWebApiAspNetCore.Models;
using System;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    public class ProjectController : BaseController<Project>
    {
        private readonly ODataDbContext _context;

        public ProjectController(ODataDbContext context)
        {
            _context = context;
        }

        [EnableQuery]
        [ODataRoute("Projects")]
        //[QueryValidator1()]
        public IActionResult GetItems()
        {
            return GetAll(_context.Project);
        }

        [EnableQuery]
        [ODataRoute("Projects({key})")]
        public IActionResult GetItem(Guid key)
        {
            return GetItem(_context.Project, t => t.Id == key);
        }

        [ODataRoute("Projects")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Project obj)
        {
            obj.Id = Guid.NewGuid();
            return await PostItemAsync(obj, _context);
        }

        [ODataRoute("Projects({key})")]
        [HttpPatch]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Patch([FromODataUri] Guid key, Delta<Project> obj)
        {
            return await PatchItemAsync(key, obj, _context.Project, _context, t => t.Id == key);
        }

        [ODataRoute("Projects({key})")]
        [HttpPut]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Put([FromODataUri] Guid key, Project obj)
        {
            return await PutItemAsync(obj, _context, t => t.Id == key, _context.Project);
        }

        [ODataRoute("Projects({key})")]
        [HttpDelete]
        //[EnableQuery(AllowedQueryOptions = AllowedQueryOptions.All)]
        public async Task<IActionResult> Delete([FromODataUri] Guid key)
        {
            return await DeleteItemAsync(key, _context.Project, _context);
        }
    }
}
