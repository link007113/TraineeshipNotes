using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag06.ValutaExercise.Library
{
    public class InvalidValutaException : Exception
    {
        public InvalidValutaException() 
        { 
        }

        public InvalidValutaException(string message) : base(message) 
        { 
        }

        public InvalidValutaException(string message, Exception innerException) : base(message, innerException) 
        { 
        }
        

    }
}
