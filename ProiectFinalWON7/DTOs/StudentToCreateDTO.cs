using ProiectFinalWON7.Models;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.DTOs
{
    public class StudentToCreateDTO
    {
        [MaxLength(20)]
        public string LastName { get; set; }
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Range(18,100)]
        public int Age { get; set; }
    }
}
