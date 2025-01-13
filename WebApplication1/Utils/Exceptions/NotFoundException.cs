namespace WebApplication1.Utils.Exceptions;

public class NotFoundException : Exception
{
    private const string ErrorMessage = "The requested resource was not found. Try again.";

    public NotFoundException() : base(ErrorMessage)
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}