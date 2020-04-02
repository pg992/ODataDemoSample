using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ODataWebApiAspNetCore.Controllers
{
    public abstract class BaseController<T> : ODataController where T: class
    {
        protected virtual IActionResult GetAll(DbSet<T> dataset)
        {
            return Ok(dataset);
        }

        protected virtual IActionResult GetItem(DbSet<T> dataset, Func<T, bool> predicate)
        {
            return Ok(dataset.Where(predicate));
        }

        protected virtual async Task<IActionResult> PostItemAsync(T e, DbContext context)
        {
            context.Add(e);
            await context.SaveChangesAsync();
            return Created(e);
        }

        protected virtual async Task<IActionResult> PatchItemAsync(Guid key, Delta<T> obj, DbSet<T> dataset, DbContext context, Func<T, bool> predicate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entity = await dataset.FindAsync(key);
            if (entity == null)
            {
                return NotFound();
            }
            obj.Patch(entity);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exist(dataset, predicate))
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

        protected virtual async Task<IActionResult> PutItemAsync(T update, DbContext context, Func<T, bool> predicate, DbSet<T> dataset)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (!Exist(dataset, predicate))
            {
                return BadRequest();
            }
            context.Entry(update).State = EntityState.Modified;
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exist(dataset, predicate))
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

        protected virtual async Task<IActionResult> DeleteItemAsync(Guid key, DbSet<T> dataset, DbContext context)
        {
            var appVersions = await dataset.FindAsync(key);
            if (appVersions == null)
            {
                return NotFound();
            }
            dataset.Remove(appVersions);
            await context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool Exist(DbSet<T> dataset, Func<T, bool> predicate)
        {
            return dataset.Any(predicate);
        }
    }
}
