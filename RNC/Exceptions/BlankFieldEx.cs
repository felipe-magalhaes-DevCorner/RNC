using System;

namespace RNC.Exceptions
{
    class BlankFieldEx : Exception
    {

        string messagetoshow;
        public BlankFieldEx(string message)
        {

            messagetoshow = message;
        }
        public override string ToString()
        {
            return messagetoshow;
        }
    }
}
