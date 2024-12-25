namespace Oyun.Exceptions.Word
{
    public class WordNotFoundException : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status404NotFound;

        public string ErrorMessage { get; }

        //public WordNotFoundException()
        //{
        //    ErrorMessage = "Bu söz tapılmadı";
        //}

        public WordNotFoundException(string message = "Bu söz tapılmadı") : base(message)
        {
            ErrorMessage = message;
        }
    }
}
