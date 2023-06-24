using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FollowTask.Data;
using FollowTask.Data.Entities;

namespace FollowTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly DataContext _context;

        public TasksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tasks>>> GetTasks()
        {
          if (_context.Tasks == null)
          {
              return NotFound();
          }
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/Tasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tasks>> GetTasks(int id)
        {
          if (_context.Tasks == null)
          {
              return NotFound();
          }
            var tasks = await _context.Tasks.FindAsync(id);

            if (tasks == null)
            {
                return NotFound();
            }

            return tasks;
        }

        // PUT: api/Tasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> CreateTasks(int id, Tasks tasks)
        {
            if (id != tasks.Id)
            {
                return BadRequest();
            }

            _context.Entry(tasks).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TasksExists(id))
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

        // POST: api/Tasks
        [HttpPost]
        public async Task<ActionResult<Tasks>> UpDateTasks(Tasks tasks)
        {
          if (_context.Tasks == null)
          {
              return Problem("Entity set 'DataContext.Tasks'  is null.");
          }
            _context.Tasks.Add(tasks);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTasks", new { id = tasks.Id }, tasks);
        }

        // DELETE: api/Tasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTasks(int id)
        {
            if (_context.Tasks == null)
            {
                return NotFound();
            }
            var tasks = await _context.Tasks.FindAsync(id);
            if (tasks == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(tasks);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TasksExists(int id)
        {
            return (_context.Tasks?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
