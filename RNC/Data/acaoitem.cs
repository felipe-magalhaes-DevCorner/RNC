using System;
using System.Collections.Generic;

namespace RNC
{
    public class acaoitem
    {




        public acaoitem(int id = 0)
        {
            DateTime? dt = null;
            this.id = id;
            this.descricao = null;
            this.prevista = Convert.ToDateTime(dt);
            this.realizada = Convert.ToDateTime(dt);
            this.previstapara = Convert.ToDateTime(dt);
            this.eficaz = false;
            this.verificadopor = null;
            this.dataverificadopor = Convert.ToDateTime(dt);
            this.observacoes = null;
            this.abertonovorelatorio = false;
            this.novorelatorio = null;
            this.datanovorelatorio = Convert.ToDateTime(dt);
        }

        public acaoitem(int id, string descricao, DateTime prevista, DateTime realizada, DateTime previstapara, bool eficaz, string verificadopor, DateTime dataverificadopor, string observacoes, bool abertonovorelatorio, string novorelatorio, DateTime datanovorelatorio)
        {
            this.id = id;
            this.descricao = descricao;
            this.prevista = prevista;
            this.realizada = realizada;
            this.previstapara = previstapara;
            this.eficaz = eficaz;
            this.verificadopor = verificadopor;
            this.dataverificadopor = dataverificadopor;
            this.observacoes = observacoes;
            this.abertonovorelatorio = abertonovorelatorio;
            this.novorelatorio = novorelatorio;
            this.datanovorelatorio = datanovorelatorio;
        }

        public string descricaoacao()
        {
            return string.Concat("'", descricao, "', '", prevista.ToString("MM/dd/yyyy"), "', '",
                realizada.ToString("MM/dd/yyyy"), "','", previstapara.ToString("MM/dd/yyyy"), "', '", eficaz.ToString(),
                "', '", verificadopor, "', '", dataverificadopor.ToString("MM/dd/yyyy"), "', '", observacoes, "', '",
                abertonovorelatorio.ToString(), "', '", novorelatorio, "' , '",
                datanovorelatorio.ToString("MM/dd/yyyy"), "', '", tipo, "'");




        }


        public List<string> RetornaUpdateAcao()
        {
            return new List<string>
            {
                id.ToString(),
                descricao,
                prevista.ToString("MM/dd/yyyy"),
                realizada.ToString("MM/dd/yyyy"),
                previstapara.ToString("MM/dd/yyyy"),
                eficaz.ToString(),
                verificadopor,
                dataverificadopor.ToString("MM/dd/yyyy"),
                observacoes,
                abertonovorelatorio.ToString(),
                novorelatorio,
                datanovorelatorio.ToString("MM/dd/yyyy"),
                tipo.ToString()



            };
        }


        //public bool Equals(acaoitem other)
        //{
        //    if (other == null)
        //    {
        //        return true;
        //    }
        //    if (this.data == other.data && this.datanovorelatorio == other.datanovorelatorio && this.descricao == other.descricao && this.prevista == other.prevista)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        #region variaveis
        public int id { get; set; }
        public string descricao { get; set; }

        public DateTime prevista { get; set; }
        public DateTime realizada { get; set; }
        public DateTime previstapara { get; set; }

        public bool eficaz { get; set; }

        public string verificadopor { get; set; }

        public DateTime dataverificadopor { get; set; }
        public string observacoes { get; set; }

        public bool abertonovorelatorio { get; set; }
        public string novorelatorio { get; set; }
        public DateTime datanovorelatorio { get; set; }

        public string tipo { get; set; }
        #endregion
    }
}
