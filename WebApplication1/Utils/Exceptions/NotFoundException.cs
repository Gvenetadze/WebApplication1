namespace WebApplication1.Utils.Exceptions;

public class NotFoundException : Exception
{
    private const string ErrorMessage = "ეს მონაცემი არ მოიპოვება, სცადე თავიდან.";

    public NotFoundException() : base(ErrorMessage)
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}