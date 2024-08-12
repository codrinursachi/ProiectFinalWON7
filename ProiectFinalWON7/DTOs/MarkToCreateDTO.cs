using ProiectFinalWON7.Models;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.DTOs
{
    public class MarkToCreateDTO
    {
        [Range(1,10)]
        public int Value { get; set; }
        [Range(1,int.MaxValue)]
        public int StudentId { get; set; }
        [Range(1, int.MaxValue)]
        public int SubjectId { get; set; }
    }
}
