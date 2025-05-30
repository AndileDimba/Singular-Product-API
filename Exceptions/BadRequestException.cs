namespace Singular_Product_API.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string name, object key) : base($"{name} ({key}) is invalid")
        { }
    }
}
