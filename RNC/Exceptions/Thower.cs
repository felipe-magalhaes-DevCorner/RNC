using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNC.Exceptions
{
    public static class Thower
    {
        #region Thowers

        #endregion
        public static void BlackFieldThrower(string _string)
        {
            if (_string == null || _string == "")
            {
                throw new Exceptions.BlankFieldEx("Campo obrigatorio não preenchido!");

            }

        }




    }
}
