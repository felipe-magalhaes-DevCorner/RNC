using System.Collections.Generic;
using System.Threading.Tasks;

namespace RNC.comunicacao
{
    internal class colecaoBase
    {
        private static List<acaoitem> colecaoacaoitemBase = new List<acaoitem>();

        private static int count;

        public List<acaoitem> GetListAsync()
        {
            return colecaoacaoitemBase;
        }

        public void SetList(List<acaoitem> _colecaoacaoitemBase)
        {
            colecaoacaoitemBase = _colecaoacaoitemBase;
            count = colecaoacaoitemBase.Count;
        }

        public int getCount()
        {
            return count;
        }

        public void SetCount(int i)
        {
            count = i;
        }

    }
}