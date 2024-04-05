using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PruebaFinanzauto.Models

{
    public class Subject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }

        // Relacion con el curso
        public int CourseId { get; set; }
        public Course Course { get; set; }

        // Relacion con las notas
        public ICollection<Grade> Grades { get; set; }
    }
}
