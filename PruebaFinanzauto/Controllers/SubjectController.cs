using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DTO_s;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ILogger<SubjectController> _logger;
        private readonly ApplicationDbContext _context;

        public SubjectController(ILogger<SubjectController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        /**
         * Metodo para obtener todas las materias registradas 
         */
        public async Task<ActionResult<IEnumerable<SubjectDto>>> GetSubjects()
        {
            try
            {
                var subjects = await _context.Subjects
                    .Include(s => s.Course)
                    .ToListAsync();

                var subjectDtos = subjects.Select(s => new SubjectDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    CourseId = s.CourseId
                }).ToList();

                return Ok(subjectDtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de materias");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        /**
         * Metodo para obtener una materia por id 
         */
        public async Task<ActionResult<SubjectDto>> GetSubject(int id)
        {
            try
            {
                var subject = await _context.Subjects
                    .Include(s => s.Course)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (subject == null)
                {
                    return NotFound();
                }

                var subjectDto = new SubjectDto
                {
                    Id = subject.Id,
                    Name = subject.Name,
                    Description = subject.Description,
                    CourseId = subject.CourseId
                };

                return Ok(subjectDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la materia con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        /**
         * Metodo para actualizar una materia 
         */
        public async Task<IActionResult> UpdateSubject(int id, SubjectDto subjectDto)
        {
            try
            {
                if (id != subjectDto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var subject = await _context.Subjects.FindAsync(id);

                if (subject == null)
                {
                    return NotFound("Subject not found");
                }

                subject.Name = subjectDto.Name;
                subject.Description = subjectDto.Description;
                subject.CourseId = subjectDto.CourseId;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!SubjectExists(id))
                {
                    _logger.LogError(ex, "Materia no encontrada con ID: {Id}", id);
                    return NotFound("Subject not found");
                }
                else
                {
                    _logger.LogError(ex, "Error al actualizar la materia con ID: {Id}", id);
                    return StatusCode(500, "Internal server error");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la materia con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        /**
         * Metodo para crear una materia 
         */
        public async Task<ActionResult<SubjectDto>> CreatetSubject(SubjectDto subjectDto)
        {
            try
            {
                var subject = new Subject
                {
                    Name = subjectDto.Name,
                    Description = subjectDto.Description,
                    CourseId = subjectDto.CourseId
                };

                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();

                subjectDto.Id = subject.Id;

                return CreatedAtAction(nameof(GetSubject), new { id = subject.Id }, subjectDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al crear una nueva materia");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        /**
         * Metodo para eliminar una materia 
         */
        public async Task<IActionResult> DeleteSubject(int id)
        {
            try
            {
                var subject = await _context.Subjects.FindAsync(id);
                if (subject == null)
                {
                    return NotFound("Subject not found");
                }

                _context.Subjects.Remove(subject);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la materia con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        private bool SubjectExists(int id)
        {
            return _context.Subjects.Any(e => e.Id == id);
        }
    }


}
