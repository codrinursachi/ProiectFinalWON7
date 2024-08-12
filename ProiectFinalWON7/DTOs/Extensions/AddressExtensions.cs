using ProiectFinalWON7.Models;

namespace ProiectFinalWON7.DTOs.Extensions
{
    public static class AddressExtensions
    {
        public static AddressToGetDTO ToAdressToGetDTO(this Address address)
        {
            if(address == null)
            {
                return null;
            }

            return new AddressToGetDTO {Id=address.Id, City = address.City, Street = address.Street, Number = address.Number, StudentId=address.StudentId };
        }

        public static Address ToAddress(this AddressToCreateDTO address)
        {
            if (address == null)
            {
                return null;
            }

            return new Address { City = address.City, Street = address.Street, Number = address.Number};
        }
    }
}
