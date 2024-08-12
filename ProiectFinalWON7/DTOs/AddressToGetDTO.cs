using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs
{
    public class AddressToGetDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public int? StudentId { get; set; }
    }
}
