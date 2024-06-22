namespace Portfolio.Core.Exceptions
{
    public class UserAuthenticationException : Exception
    {
        public UserAuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
