namespace Oyun.Exceptions.Word;

public class WordExistException : Exception, IBaseException
{
    public int StatusCode => StatusCodes.Status409Conflict;

    public string ErrorMessage { get; }

    //public WordExistException()
    //{
    //    ErrorMessage = "Bu dildə bu söz artıq mövcuddur.";
    //}

    public WordExistException(string message = "Bu dildə bu söz artıq mövcuddur.") : base(message)
    {
        ErrorMessage = message;
    }
}
