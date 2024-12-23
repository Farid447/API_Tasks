namespace Oyun.Exceptions.Language;

public class LanguageExistException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    //public LanguageExistException()
    //{
    //    ErrorMessage = "Bu dil artıq mövcuddur";
    //}

    public LanguageExistException(string message = "Bu dil artıq mövcuddur") : base(message)
    {
        ErrorMessage = message;
    }
}
