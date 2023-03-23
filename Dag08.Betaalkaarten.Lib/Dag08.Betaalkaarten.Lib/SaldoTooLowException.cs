using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag08.Betaalkaarten.Lib
{
    [Serializable]
    public class SaldoTooLowException : Exception
    {
        public SaldoTooLowException()
        { }

        public SaldoTooLowException(string message) : base(message)
        {
        }

        public SaldoTooLowException(string message, Exception inner) : base(message, inner)
        {
        }

        protected SaldoTooLowException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}