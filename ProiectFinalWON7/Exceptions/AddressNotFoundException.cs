namespace ProiectFinalWON7.Exceptions
{
    public class AddressNotFoundException:Exception
    {
        public AddressNotFoundException()
        {
        }

        public AddressNotFoundException(string? message) : base(message)
        {
        }

        public AddressNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
