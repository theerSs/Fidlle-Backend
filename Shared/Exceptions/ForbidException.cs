namespace Fidlle.Shared.Exceptions
{
    public class ForbidException : Exception
    {
        public ForbidException() : base("Forbidden")
        {
        }

        public ForbidException(string message) : base(message)
        {
        }

        public ForbidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}