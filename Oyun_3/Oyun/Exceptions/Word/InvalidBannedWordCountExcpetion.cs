namespace Oyun.Exceptions.Word
{
    public class InvalidBannedWordCountExcpetion : Exception, IBaseException
    {
        public int StatusCode => StatusCodes.Status400BadRequest;

        public string ErrorMessage { get; }
        
        //public InvalidBannedWordCountExcpetion()
        //{
        //    ErrorMessage = "Bloklanmış söz sayı 8 olmalıdır.";
        //}

        public InvalidBannedWordCountExcpetion(string message = "Bloklanmış söz sayı 8 olmalıdır.") : base(message)
        {
            ErrorMessage = message;
        }
    }
}
