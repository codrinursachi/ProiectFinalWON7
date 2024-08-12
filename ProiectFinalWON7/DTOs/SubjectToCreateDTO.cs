using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.DTOs
{
    public class SubjectToCreateDTO
    {
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
