using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pdf6b2.Models;
using pdf6b3.Databases;
using pdf6b3.Interfaces;

namespace pdf6b3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectsController : ControllerBase
    {
        private readonly StudentDbContext _context;
        private readonly ISubject _subject;

        public SubjectsController(StudentDbContext context, ISubject subject)
        {
            _context = context;
            _subject = subject;
        }

        // GET: api/Subjects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subject>>> GetSubjects()
        {
          if (_context.Subjects == null)
          {
              return NotFound();
          }
            return _subject.GetSubjects();
        }

        // GET: api/Subjects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Subject>> GetSubject(int id)
        {
          if (_context.Subjects == null)
          {
              return NotFound();
          }
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            return subject;
        }

        // PUT: api/Subjects/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubject(int id, Subject subject)
        {
            if (id != subject.Id)
            {
                return BadRequest();
            }

            _context.Subjects.Update(subject);
            return NoContent();
        }

        // POST: api/Subjects
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Subject>> PostSubject(Subject subject)
        {
          if (_context.Subjects == null)
          {
              return Problem("Entity set 'StudentDbContext.Subjects'  is null.");
          }
            _subject.Update(subject,subject.Id);

            return CreatedAtAction("GetSubject", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubject(Subject e)
        {
            if (_context.Subjects == null)
            {
                return NotFound();
            }

            _subject.Delete(e);

            return NoContent();
        }

        private bool SubjectExists(int id)
        {
            return (_context.Subjects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
