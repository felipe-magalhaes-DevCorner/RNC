using System;

namespace RNC.Exceptions
{
    class WrongDatetime : Exception
    {
        string messagetoshow;
        public WrongDatetime(string message)
        {

            messagetoshow = message;
        }
        public override string ToString()
        {
            return messagetoshow;
        }

    }
}
