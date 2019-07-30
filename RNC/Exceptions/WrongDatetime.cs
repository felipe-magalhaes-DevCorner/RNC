using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
