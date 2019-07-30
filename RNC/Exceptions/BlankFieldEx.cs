using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
