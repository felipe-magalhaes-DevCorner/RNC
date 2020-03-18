using System;

namespace RNC.Exceptions
{
    public class NoButtonSelected : Exception
    {
        string messagetoshow;

        public NoButtonSelected(string message)
        {

            messagetoshow = message;
        }
        public override string ToString()
        {
            return messagetoshow;
        }


    }
}
