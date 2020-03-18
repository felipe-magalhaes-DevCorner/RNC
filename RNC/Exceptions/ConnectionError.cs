using System;

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
