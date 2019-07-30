using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RNC
{
    class ConnectionClass
    {
        #region Variables
        // We use these three Sql objects:
        private SqlConnection _conn;
        private SqlCommand _cmd;
        private SqlDataReader _datareader;
        private SqlDataAdapter _datadapter;
        private DataTable _dt;

        #endregion

        #region Configuração
        public void SqlConnection()
        {
            /////------------------------- AKI DIZEMOS AONDE ESTA O SQL-------------------------------
            //A _CONN PRIMEIRA  e segunda É MINHA A terceira DE VOCES SE TIVER UM ERRO CHECAR AKI PRIMEIRO.

            //_conn = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=Hospedaria;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //_conn = new SqlConnection("Data Source = ANDROIDK1; Initial Catalog = Hospedaria; Persist Security Info = True; User ID = sa; Password = root");
            //----------------- suas
            _conn = new SqlConnection("Data Source=192.168.0.11;Initial Catalog=RNC;Integrated Security=False;User ID=sa;Password=n3fr0d@t@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            //_conn = new SqlConnection("Data Source=192.168.0.11;Initial Catalog=RNC;Integrated Security=False;User ID=sa;Password=n3fr0d@t@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            //_conn = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=RNC;Integrated Security=True");
            /////------------------------- ABRO A CONEXAO-------------------------------
            try
            {
                _conn.Open();
                if (_conn != null && _conn.State == ConnectionState.Closed)
                {
                    throw new Exceptions.ConnectionError("Sem comunicação com o banco de dados!");
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        #endregion
        #region Handlers
        public void SqlQuery(string pQueryText)        
        {
            /////------------------------- DOU COLAR NA QUERO NO SQL E DIGO AONDE COLAR-------------------------------
            _cmd = new SqlCommand(pQueryText, _conn);
        }
        public DataTable ReturnDT()
        {
            /////------------------------- ME RETORNA UMA TABELA COM O RESULTADO-------------------------------
            _datadapter = new SqlDataAdapter(_cmd);
            _dt = new DataTable();
            _datadapter.Fill(_dt);
            return _dt;
        }
        public SqlDataReader SingleCellReader()
        {
            /////------------------------- EXECUTA A QUERY E -------------------------------
            /////------------------------- ME RETORNA UM LEITOR, PARA LER AS CELULAS DO RESULTADO DA QUERY-------------------------------
            _datareader = _cmd.ExecuteReader();
            return _datareader;
        }
        public void QueryRun()
        {
            /////------------------------- EXECUTA A QUERY(COMANDOS ---INSERT / UPDATE AKI-------------------------------
            _cmd.ExecuteNonQuery();
        }
        public void RunQueryList(List<string> _queries)
        {
            //executes a list of strings of commands with no returns.
            foreach (string query in _queries)
            {
                _cmd = new SqlCommand(query, _conn);
                _cmd.ExecuteNonQuery();
            }
        }

        public void closeConnection()
        {
            /////------------------------- FECHO A CONEXAO-------------------------------
            _conn.Close();
            _conn.Dispose();
        }
        #endregion



    }
}
