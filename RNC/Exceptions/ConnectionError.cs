using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNC.Exceptions
{
    public class ConnectionError : Exception
    {
        string messagetoshow;

        public ConnectionError(string message)
        {

            messagetoshow = message;
        }
        public override string ToString()
        {
            return messagetoshow;
        }
    }
}
