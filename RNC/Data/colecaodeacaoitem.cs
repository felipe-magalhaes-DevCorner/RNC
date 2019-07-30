using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNC
{
    public class colecaodeacaoitem : List<acaoitem>
    {
        public List<acaoitem> colecaoacaoitem = new List<acaoitem>();

        public static string rncid
        {
            get;
            set;
        }

        public void AddList(acaoitem _acaoitem)
        {
            this.colecaoacaoitem.Add(_acaoitem);
        }

        public List<acaoitem> GetList()
        {
            new List<acaoitem>();
            return this.colecaoacaoitem;
        }

        public int ListCount()
        {
            return this.colecaoacaoitem.Count<acaoitem>();
        }

        public void RemoveList(acaoitem _acaoitem)
        {
            this.colecaoacaoitem.Remove(_acaoitem);
        }

        public void SetList(List<acaoitem> _list)
        {
            this.colecaoacaoitem = _list;
        }

        public acaoitem GetAcaoByIndex(int _index)
        {
            return this.colecaoacaoitem[_index];
        }

        public void ClearAcoes()
        {
            this.colecaoacaoitem.Clear();
        }

        public colecaodeacaoitem GetColecao()
        {
            return this;
        }



    }
}
