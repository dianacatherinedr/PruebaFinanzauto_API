using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DTO_s;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class CourseController : ControllerBase
   {
       private readonly ILogger<CourseController> _logger;
       private readonly ApplicationDbContext _context;

       public CourseController(ILogger<CourseController> logger, ApplicationDbContext context)
       {
            _logger = logger;
            _context = context;

       }

        [HttpGet]
        /**
         * Metodo para obtener todos los cursos 
         */
        public async Task<ActionResult<IEnumerable<CourseDto>>> GetCourses()
        {
            try
            {
                var courses = await _context.Courses.ToListAsync();

                var courseDtos = courses.Select(c => new CourseDto
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToList();

                return Ok(courseDtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de cursos");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        /**
         * Metodo para obtener un curso por Id 
         */
        public async Task<ActionResult<CourseDto>> GetCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);

                if (course == null)
                {
                    return NotFound();
                }

                var courseDto = new CourseDto
                {
                    Id = course.Id,
                    Name = course.Name
                };

                return Ok(courseDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el curso con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        /**
         * Metodo para actualizar un curso 
         */
        public async Task<IActionResult> UpdateCourse(int id, CourseDto courseDto)
        {
            try
            {
                if (id != courseDto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var course = await _context.Courses.FindAsync(id);

                if (course == null)
                {
                    return NotFound("Course not found");
                }

                course.Name = courseDto.Name;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!CourseExists(id))
                {
                    _logger.LogError(ex, "Curso no encontrado con ID: {Id}", id);
                    return NotFound("Course not found");
                }
                else
                {
                    _logger.LogError(ex, "Error al actualizar el curso con ID: {Id}", id);
                    return StatusCode(500, "Internal server error");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el curso con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        /**
         * Metodo para crear un curso 
         */
        public async Task<ActionResult<CourseDto>> CreateCourse(CourseDto courseDto)
        {
            try
            {
                var course = new Course
                {
                    Name = courseDto.Name
                };

                _context.Courses.Add(course);
                await _context.SaveChangesAsync();

                courseDto.Id = course.Id;

                return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, courseDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo curso");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        /**
         * Metodo para eliminar curso 
         */
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                var course = await _context.Courses.FindAsync(id);
                if (course == null)
                {
                    return NotFound("Course not found");
                }

                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el curso con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.Id == id);
        }


    }
}
