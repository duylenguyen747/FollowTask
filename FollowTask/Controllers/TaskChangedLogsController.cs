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
    public class TaskChangedLogsController : ControllerBase
    {
        private readonly DataContext _context;

        public TaskChangedLogsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/TaskChangedLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskChangedLog>>> GetTasksChangedLogs()
        {
          if (_context.TasksChangedLogs == null)
          {
              return NotFound();
          }
            return await _context.TasksChangedLogs.ToListAsync();
        }

        // GET: api/TaskChangedLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskChangedLog>> GetTaskChangedLog(int id)
        {
          if (_context.TasksChangedLogs == null)
          {
              return NotFound();
          }
            var taskChangedLog = await _context.TasksChangedLogs.FindAsync(id);

            if (taskChangedLog == null)
            {
                return NotFound();
            }

            return taskChangedLog;
        }

        // PUT: api/TaskChangedLogs/5
        [HttpPut("{id}")]
        public async Task<IActionResult> CreateTaskChangedLog(int id, TaskChangedLog taskChangedLog)
        {
            if (id != taskChangedLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskChangedLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskChangedLogExists(id))
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

        // POST: api/TaskChangedLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskChangedLog>> UpdateTaskChangedLog(TaskChangedLog taskChangedLog)
        {
          if (_context.TasksChangedLogs == null)
          {
              return Problem("Entity set 'DataContext.TasksChangedLogs'  is null.");
          }
            _context.TasksChangedLogs.Add(taskChangedLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskChangedLog", new { id = taskChangedLog.Id }, taskChangedLog);
        }

        // DELETE: api/TaskChangedLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskChangedLog(int id)
        {
            if (_context.TasksChangedLogs == null)
            {
                return NotFound();
            }
            var taskChangedLog = await _context.TasksChangedLogs.FindAsync(id);
            if (taskChangedLog == null)
            {
                return NotFound();
            }

            _context.TasksChangedLogs.Remove(taskChangedLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskChangedLogExists(int id)
        {
            return (_context.TasksChangedLogs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
