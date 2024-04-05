using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DTO_s;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly ILogger<GradeController> _logger;
        private readonly ApplicationDbContext _context;

        public GradeController(ILogger<GradeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        /**
         * Metodo para obtener las notas 
         */
        public async Task<ActionResult<IEnumerable<GradeDto>>> GetGrades()
        {
            try
            {
                var grades = await _context.Grades
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                    .ToListAsync();

                var gradeDtos = grades.Select(g => new GradeDto
                {
                    Id = g.Id,
                    StudentId = g.StudentId,
                    SubjectId = g.SubjectId,
                    Value = g.Value
                }).ToList();

                return Ok(gradeDtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de calificaciones");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        /**
         * Metodo para obtener notas segun Id 
         */
        public async Task<ActionResult<GradeDto>> GetGrade(int id)
        {
            try
            {
                var grade = await _context.Grades
                    .Include(g => g.Student)
                    .Include(g => g.Subject)
                    .FirstOrDefaultAsync(g => g.Id == id);

                if (grade == null)
                {
                    return NotFound();
                }

                var gradeDto = new GradeDto
                {
                    Id = grade.Id,
                    StudentId = grade.StudentId,
                    SubjectId = grade.SubjectId,
                    Value = grade.Value
                };

                return Ok(gradeDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la calificación con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        /**
         * Metodo para actualizar una nota 
         */
        public async Task<IActionResult> UpdateGrade(int id, GradeDto gradeDto)
        {
            try
            {
                if (id != gradeDto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var grade = await _context.Grades.FindAsync(id);

                if (grade == null)
                {
                    return NotFound("Grade not found");
                }

                grade.StudentId = gradeDto.StudentId;
                grade.SubjectId = gradeDto.SubjectId;
                grade.Value = gradeDto.Value;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!GradeExists(id))
                {
                    _logger.LogError(ex, "Calificación no encontrada con ID: {Id}", id);
                    return NotFound("Grade not found");
                }
                else
                {
                    _logger.LogError(ex, "Error al actualizar la calificación con ID: {Id}", id);
                    return StatusCode(500, "Internal server error");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar la calificación con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        /**
         * Metodo para crear una nota 
         */
        public async Task<ActionResult<GradeDto>> CreateGrade(GradeDto gradeDto)
        {
            try
            {
                var grade = new Grade
                {
                    StudentId = gradeDto.StudentId,
                    SubjectId = gradeDto.SubjectId,
                    Value = gradeDto.Value
                };

                _context.Grades.Add(grade);
                await _context.SaveChangesAsync();

                gradeDto.Id = grade.Id;

                return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, gradeDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al crear una nueva calificación");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        /**
         * Metodo para eliminar una nota 
         */
        public async Task<IActionResult> DeleteGrade(int id)
        {
            try
            {
                var grade = await _context.Grades.FindAsync(id);
                if (grade == null)
                {
                    return NotFound("Grade not found");
                }

                _context.Grades.Remove(grade);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar la calificación con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        private bool GradeExists(int id)
        {
            return _context.Grades.Any(e => e.Id == id);
        }
    }
}
