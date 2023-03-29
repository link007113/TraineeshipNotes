using System.Runtime.Serialization;

namespace Day11.BarExcercise.Lib
{
    [Serializable]
    public class PaymentInsufficientException : Exception
    {
        public PaymentInsufficientException()
        {
        }

        public PaymentInsufficientException(string? message) : base(message)
        {
        }

        public PaymentInsufficientException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected PaymentInsufficientException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}