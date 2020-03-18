using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNC.Configuration
{
    public static  class Config
    {
        private static string temporarysavelocation = AppDomain.CurrentDomain.BaseDirectory + "\\tmp";
        public static string GetTempLocation()
        {
            return temporarysavelocation;
        }
    }
}
