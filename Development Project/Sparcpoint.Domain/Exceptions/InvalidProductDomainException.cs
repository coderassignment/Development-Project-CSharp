using System;

namespace Sparcpoint.Domain.Exceptions
{
    /// <summary>
    /// Exception type for domain exceptions
    /// </summary>
    public class InvalidProductDomainException : ArgumentException
    {
        public InvalidProductDomainException()
        { }

        public InvalidProductDomainException(string message)
            : base(message)
        { }

        public InvalidProductDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
