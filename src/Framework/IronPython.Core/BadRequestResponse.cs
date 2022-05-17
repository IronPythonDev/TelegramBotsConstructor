namespace IronPython.Core
{
    public class BadRequestResponse
    {
        public BadRequestResponse(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}
