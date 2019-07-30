using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RNC
{
    class buscar
    {



        ConnectionClass db = new ConnectionClass();
        public consulta objConsulta { get; set; }
        private DataTable _dt;
        


        

        public string M_peganumerornc()
        {
            db.SqlConnection();
            string query = "  SELECT TOP 1 idnc FROM [naoconformidade]    WHERE SUBSTRING( idnc, 5,4) = YEAR(GETDATE())   order by 1 desc ";
            db.SqlQuery(query);
            string rncNumber = "0";
            SqlDataReader _reader = db.SingleCellReader();
            string numerofinal;
            if (_reader.HasRows == true)
            {
                numerofinal = "1";
                while (_reader.Read())
                {
                    rncNumber = _reader["idnc"].ToString();
                    int id = Convert.ToInt32(rncNumber.Substring(0, 3));
                    int year = Convert.ToInt32(rncNumber.Substring(4, 4));
                    if (year == DateTime.Now.Year)
                    {
                        id++;
                        numerofinal = id.ToString("D3") + "-" + rncNumber.Substring(4, 4);

                    }
                    else
                    {
                        id = 1;
                        numerofinal =    id.ToString("D3") + "-" + DateTime.Now.Year;
                    }


                }

            }
            else
            {
                rncNumber = "001-" + DateTime.Now.Year;
                numerofinal = rncNumber;
            }


            db.closeConnection();

            return numerofinal;


        }


        public string m_pegaidacao()
        {
            db.SqlConnection();
            string query = "select top 1 idacao from descricaoacao order by idacao desc";
            db.SqlQuery(query);
            string rncNumber = "0";
            SqlDataReader _reader = db.SingleCellReader();
            string numeroid;
            if (_reader.HasRows == true)
            {
                numeroid = "1";
                while (_reader.Read())
                {
                    rncNumber = _reader["idacao"].ToString();

                    numeroid = rncNumber;
                }

            }
            else
            {
                rncNumber = "01";
                numeroid = rncNumber;
            }


            db.closeConnection();

            return numeroid;


        }


        public string M_peganumerornc2()
        {
            db.SqlConnection();
            string query = "select top 1 idnc from naoconformidade order by idnc desc";
            db.SqlQuery(query);
            string rncNumber = "0";
            SqlDataReader _reader = db.SingleCellReader();
            string numerofinal;
            if (_reader.HasRows == true)
            {
                numerofinal = "1";
                while (_reader.Read())
                {
                    rncNumber = _reader["idnc"].ToString();
                    int id = Convert.ToInt32(rncNumber.Substring(0, 3));
                    numerofinal = id.ToString("D3") + "-" + rncNumber.Substring(4, 4);

                }

            }
            else
            {
                rncNumber = "001-" + DateTime.Now.Year;
                numerofinal = rncNumber;
            }


            db.closeConnection();

            return numerofinal;
        }


        public relatorio PegaRelatorioSql(string _idrnc)
        {

            relatorio _relatorio = null;
            colecaodeacaoitem colecao = new colecaodeacaoitem();
            string Query = "SELECT * FROm naoconformidade where idnc = '"+ _idrnc + "'";
            db.SqlConnection();
            db.SqlQuery(Query);
            db.QueryRun();
            DataTable dt = db.ReturnDT();
            if (dt.Rows.Count > 0)
            {
                string rncid = "";
                string rncdescricao = "";
                string emitente = "";
                DateTime data = Convert.ToDateTime("01/01/0001");
                string setor = "";
                string origem = "";
                string tratamento = "";
                string investigacao = "";
                string disposicao = "";
                string status = "";
                string risco = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    rncid = dt.Rows[i].Field<string>(0);
                    rncdescricao = dt.Rows[i].Field<string>(1);
                    emitente = dt.Rows[i].Field<string>(2);
                    data = dt.Rows[i].Field<DateTime>(3);
                    setor = dt.Rows[i].Field<string>(4);
                    origem = dt.Rows[i].Field<string>(5);
                    tratamento = dt.Rows[i].Field<string>(6);
                    investigacao = dt.Rows[i].Field<string>(7);
                    disposicao = dt.Rows[i].Field<string>(8);
                    status = dt.Rows[i].Field<string>(9);
                    risco = dt.Rows[i].Field<string>(10);

                }
                string Queryacao = "SELECT * FROm descricaoacao inner join naoconformidade_descricaoacao on (naoconformidade_descricaoacao.idacao = descricaoacao.idacao) where idnc = '"+_idrnc+"'";
                db.SqlQuery(Queryacao);
                db.QueryRun();
                DataTable dt2 = db.ReturnDT();
                if (dt2.Rows.Count>0)
                {
                    List<acaoitem> ListaDeAcoes = new List<acaoitem>(); 


                        for (int i = 0; i < dt2.Rows.Count; i++)
                        {
                            int id;
                        string descricao;
                        DateTime prevista;
                        DateTime realizada;
                        DateTime previstapara;
                        string eficaz;
                        string verificadopor;
                        DateTime dataverificapor;
                        string observacoes;
                        string abertonovorelaro;
                        string novorelatorionumero;
                        
                        DateTime novorelatoriodata;

                            id = dt2.Rows[i].Field<int>(0);
                            descricao = dt2.Rows[i].Field<string>(1);
                            prevista = dt2.Rows[i].Field<DateTime>(2);
                            realizada = dt2.Rows[i].Field<DateTime>(3);
                            previstapara = dt2.Rows[i].Field<DateTime>(4);
                            eficaz = dt2.Rows[i].Field<string>(5);
                            verificadopor = dt2.Rows[i].Field<string>(6);
                            dataverificapor = dt2.Rows[i].Field<DateTime>(7);
                            observacoes = dt2.Rows[i].Field<string>(8);
                            abertonovorelaro = dt2.Rows[i].Field<string>(9);
                            novorelatorionumero = dt2.Rows[i].Field<string>(10);
                            novorelatoriodata = dt2.Rows[i].Field<DateTime>(11);
                            
                            acaoitem novaacao = new acaoitem(id, descricao, prevista, realizada, previstapara,Convert.ToBoolean( eficaz), verificadopor, dataverificapor, observacoes,Convert.ToBoolean( abertonovorelaro), novorelatorionumero, novorelatoriodata);
                            ListaDeAcoes.Add(novaacao);

                        }
                    
                    
                    colecao.SetList(ListaDeAcoes);
                    
                }
                _relatorio = new relatorio(rncid, rncdescricao, emitente, data, setor, origem, tratamento, investigacao, disposicao, status, colecao, risco);



            }
            db.closeConnection();
            return _relatorio;

        }
        public void GetRelatorio()
        {
            db.SqlConnection();
            string query = "select idnc, descricaonc, emitentenc, datanc, setor, origemnc, tratamentonc, investicacaonc, disposicaonc, situacao, risco from naoconformidade";

            db.SqlQuery(query);
            DataTable dt = db.ReturnDT();
            foreach (DataRow row in dt.Rows)
            {

                string IDNC = row["idnc"].ToString();
                string desricao = row["descricaonc"].ToString();
                string emitentenc = row["emitentenc"].ToString();
                DateTime data = Convert.ToDateTime(row["datanc"]);
                string setor = row["setor"].ToString();
                string origemnc = row["origemnc"].ToString();
                string tratamentonc = row["tratamentonc"].ToString();
                string investicacaonc = row["investicacaonc"].ToString();
                string disposicaonc = row["disposicaonc"].ToString();
                string situacao = row["situacao"].ToString();
                string risco = row["risco"].ToString();

            }

        }
        public void Pesquisaano()
        {
            
        string query = "";

            objConsulta.dtGridConsulta.DataSource = "";
            query = "select idnc,datanc,origemnc,setor,tratamentonc ,situacao from naoconformidade where idnc like ('%" + objConsulta.txtAno.Text + "%') ";
            db.SqlConnection();
            db.SqlQuery(query);
            Clipboard.SetText(query);
            db.QueryRun();
            _dt = db.ReturnDT();
            objConsulta.dtGridConsulta.DataSource = _dt;
            db.closeConnection();


        }

        public bool Encerrarnc()
        {
            if (objConsulta != null)
            {
                if (objConsulta.dtGridConsulta.SelectedCells.Count > 0)
                {
                    string idRNC = objConsulta.dtGridConsulta.SelectedCells[0].Value.ToString();

                    string query = "update naoconformidade set situacao = 'Fechada' from naoconformidade where idnc like('%" + idRNC + "%') ";

                    db.SqlConnection();

                    db.SqlQuery(query);

                    db.QueryRun();

                    db.closeConnection();
                    MessageBox.Show("RNC encerrada com sucesso.");
                    return true;


                }
                MessageBox.Show("Nenhuma acao selecionada.");
                return false;
            }
            MessageBox.Show("É nescessario pesquisar primeiro o ano de competencia.");
            return false;


        }








    }
}
