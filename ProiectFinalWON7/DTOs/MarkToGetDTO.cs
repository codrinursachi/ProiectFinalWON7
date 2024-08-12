using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs
{
    public class MarkToGetDTO
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime TimeOfGrading { get; set; }
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
    }
}
