using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
