using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebaFinanzauto.Models
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = default!;
        [Required]
        public string LastName { get; set; } = default!;
        [Required]
        public string Address { get; set; } = default!;
        [Required]
        public string PhoneNumber { get; set; } = default!;
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        public DateTime EnrollmentDate { get; set; } = DateTime.Now;

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        // Relacion con el curso
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Relacion con las notas
        public ICollection<Grade> Grades { get; set; }
    }

}