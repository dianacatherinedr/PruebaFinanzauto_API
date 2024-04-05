using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DTO_s;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly ApplicationDbContext _context;

        public StudentController(ILogger<StudentController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        /**
         * Metodo trae todos los estudiantes
        */
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents()
        {
            try
            {
                var students = await _context.Students
                    .Include(s => s.Course)
                    .ToListAsync();

                var studentDtos = students.Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    LastName = s.LastName,
                    Address = s.Address,
                    PhoneNumber = s.PhoneNumber,
                    Email = s.Email,
                    CourseId = s.CourseId
                }).ToList();

                return Ok(studentDtos);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener la lista de estudiantes");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        /**
         * Metodo que trae los estudiantes que pertencen a un curso especifico 
         */
        public async Task<ActionResult<StudentDto>> GetStudent(int id)
        {
            try
            {
                var student = await _context.Students
                    .Include(s => s.Course)
                    .FirstOrDefaultAsync(s => s.Id == id);

                if (student == null)
                {
                    return NotFound();
                }

                var studentDto = new StudentDto
                {
                    Id = student.Id,
                    Name = student.Name,
                    LastName = student.LastName,
                    Address = student.Address,
                    PhoneNumber = student.PhoneNumber,
                    Email = student.Email,
                    CourseId = student.CourseId
                };

                return Ok(studentDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al obtener el estudiante con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        /**
         * Metodo para actualizar un estudiante 
         */
        public async Task<IActionResult> UpdateStudent(int id, StudentDto studentDto)
        {
            try
            {
                if (id != studentDto.Id)
                {
                    return BadRequest("ID mismatch");
                }

                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    return NotFound("Student not found");
                }

                student.Name = studentDto.Name;
                student.LastName = studentDto.LastName;
                student.Address = studentDto.Address;
                student.PhoneNumber = studentDto.PhoneNumber;
                student.Email = studentDto.Email;
                student.CourseId = studentDto.CourseId;

                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!StudentExists(id))
                {
                    _logger.LogError(ex, "Estudiante no encontrado con ID: {Id}", id);
                    return NotFound("Student not found");
                }
                else
                {
                    _logger.LogError(ex, "Error al actualizar el estudiante con ID: {Id}", id);
                    return StatusCode(500, "Internal server error");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar el estudiante con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        /**
         * Metodo para crear un estudiante 
         */
        public async Task<ActionResult<StudentDto>> CreateStudent(StudentDto studentDto)
        {
            try
            {
                var student = new Student
                {
                    Name = studentDto.Name,
                    LastName = studentDto.LastName,
                    Address = studentDto.Address,
                    PhoneNumber = studentDto.PhoneNumber,
                    Email = studentDto.Email,
                    CourseId = studentDto.CourseId,
                    Created_at = DateTime.Now,
                    Updated_at = DateTime.Now
                };

                _context.Students.Add(student);
                await _context.SaveChangesAsync();

                studentDto.Id = student.Id;

                return CreatedAtAction(nameof(GetStudent), new { id = student.Id }, studentDto);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al crear un nuevo estudiante");
                return StatusCode(500, "Internal server error");
            }
        }


        [HttpDelete("{id}")]
        /**
         * Metodo para eliminar Estudiante 
         */
        public async Task<IActionResult> DeleteStudent(int id)
        {
            try
            {
                var student = await _context.Students.FindAsync(id);
                if (student == null)
                {
                    return NotFound("Student not found");
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex, "Error al eliminar el estudiante con ID: {Id}", id);
                return StatusCode(500, "Internal server error");
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.Id == id);
        }
    }
  
}
