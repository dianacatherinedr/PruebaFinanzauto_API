using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PruebaFinanzauto.DTO_s
{
    public class GradeDto
    {

        public int Id { get; set; }

        public int StudentId { get; set; }

        public int SubjectId { get; set; }

        public double Value { get; set; }
    }
}
