using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace PruebaFinanzauto.Models
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = default!;

        public string Description { get; set; } = default!;

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        // Relacion con studiantes
        public ICollection<Student> Students { get; set; }

        // Relacion con las materias
        public ICollection<Subject> Subjects { get; set; }
    }
}
