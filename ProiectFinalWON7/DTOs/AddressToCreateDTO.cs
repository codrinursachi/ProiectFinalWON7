using ProiectFinalWON7.Models;
using System.ComponentModel.DataAnnotations;

namespace ProiectFinalWON7.DTOs
{
    public class AddressToCreateDTO
    {
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(20)]
        public string Street { get; set; }
        [Range(0,100)]
        public int Number { get; set; }
    }
}
