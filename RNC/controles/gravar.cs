using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNC.comunicacao;
using RNC.controles;

namespace RNC
{
    public partial class gravar : UserControl
    {

        public static string LoggedName;

		private ConnectionClass db = new ConnectionClass();

		private buscar bc = new buscar();

		public colecaodeacaoitem colecao;


        public Form parentObj { get; set; }

        public cadastrocontrol _cadastro { get; set; }

        private relatorio relatorioRNC { get; set; }

        public string emitente { get; set; }

        public bool ShouldUpdate { get; set; }

        public bool IDChanged { get; set; }

		public gravar()
		{
			this.InitializeComponent();
		}

		public void acaotosql(colecaodeacaoitem colecao)
		{
			this.db.SqlConnection();
			List<acaoitem> expr_11 = colecao.GetList();
			int arg_17_0 = expr_11.Count;
			foreach (acaoitem acao in expr_11)
			{
				string query = "insert into descricaoacao values (" + acao.descricaoacao() + ") ";
				query = query;
				this.db.SqlQuery(query);
				this.db.QueryRun();
				string numerornc = this.bc.M_peganumerornc2();
				string numeroacao = this.bc.m_pegaidacao();
				query = string.Concat(new string[]
				{
					"insert into naoconformidade_descricaoacao values ('",
					numerornc,
					"','",
					numeroacao,
					"')"
				});
				query = query;
				this.db.SqlQuery(query);
				this.db.QueryRun();
			}
		}

		private void btSave_Click(object sender, EventArgs e)
		{
			this._cadastro = StoreRelatorio.CadastroUsing;
			relatorio relatorio = this._cadastro.ToRelatorioConvert(null);
			if (relatorio != null)
			{
				StoreRelatorio.SetRelatorio(relatorio);
				enviar SQLSEND = new enviar();
				if (this.ShouldUpdate)
				{
					SQLSEND.UPdateCadastro();
				}
				else
				{
					SQLSEND.gravar = this;
					SQLSEND.GravarToSQL();
				}
				if (!this.IDChanged)
				{
					MessageBox.Show(string.Format("RNC de numero {0}, gravada com sucesso", StoreRelatorio.GetRNCNumber()));
				}
				else
				{
					MessageBox.Show(string.Format("Número de RNC ja usado, novo número é {0} ", StoreRelatorio.GetRNCNumber()));
				}
				this._cadastro.fechar.Controls.Clear();
				if (this._cadastro.parentObj != null)
				{
					this._cadastro.parentObj.Close();
				}
			} 
		}

		private void btlimpar_Click(object sender, EventArgs e)
		{
			relatorio relatorio = null;
			cadastrocontrol cadastro = new cadastrocontrol(relatorio);
			this._cadastro.fechar.Controls.Clear();
			cadastro.fechar = this._cadastro.fechar;
			colecaodeacaoitem colecao = new colecaodeacaoitem();
			if (relatorio != null)
			{
				relatorio.setColecao(colecao);
			}
			List<acaoitem> list = new List<acaoitem>();
			colecao.SetList(list);
			cadastro.objGravarMain = this._cadastro.objGravarMain;
			cadastro.RNCID = this._cadastro.RNCID;
			cadastro.pn_botoes = this._cadastro.pn_botoes;
			cadastro.fechar.Controls.Add(cadastro);
			this._cadastro = cadastro;
		}

        private void button1_Click(object sender, EventArgs e)
        {
            buscar buscar = new buscar();
            if (buscar.Encerrarnc())
            {
                MessageBox.Show("RNC encerrada com sucesso.");
            }
            else
            {
                MessageBox.Show("RNC não pode ser encerrada, favor entrar em contato com o administrador (ERROR: 003)");
            }

            
        }
    }
}
