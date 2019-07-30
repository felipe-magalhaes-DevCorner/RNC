using RNC.controles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RNC.comunicacao
{
	public class enviar
	{
		private ConnectionClass db = new ConnectionClass();

		private cadastrocontrol cadastro
		{
			get;
			set;
		}

		public List<acaoitem> ListVelha
		{
			get;
			set;
		}

		public gravar gravar
		{
			get;
			set;
		}

		public void UPdateCadastro()
		{
			this.db.SqlConnection();
			List<string> info = StoreRelatorio.GetUpdateInfo();
			string query = string.Concat(new string[]
			{
				"update naoconformidade set  idnc = '",
				info[0],
				"',descricaonc = '",
				info[1],
				"' ,emitentenc = '",
				info[2],
				"' ,datanc= '",
				info[3],
				"' ,setor = '",
				info[4],
				"' ,origemnc = '",
				info[5],
				"' ,tratamentonc = '",
				info[6],
				"' ,investicacaonc = '",
				info[7],
				"' ,disposicaonc = '",
				info[8],
				"' ,situacao = '",
				info[9],
                "' ,risco = '",
                info[10],
				"' where idnc = '",
				info[0],
				"'"
			});
			Clipboard.SetText(query);
			this.db.SqlQuery(query);
			this.db.QueryRun();
			colecaoBase objColeção = new colecaoBase();
            objColeção.GetList();
			List<acaoitem> ListAtual = StoreRelatorio.GetList();
			int i = objColeção.getCount();
			if (ListAtual.Count > i)
			{
				for (int j = 0; j < ListAtual.Count; j++)
				{
					if (j < i)
					{
						this.update(ListAtual[j]);
					}
					else
					{
						this.insert(ListAtual[j]);
					}
				}
			}
			else
			{
				this.update(ListAtual);
			}
			this.db.closeConnection();
		}

		private void update(acaoitem _acao)
		{
			List<string> list = _acao.RetornaUpdateAcao();
			string query = string.Concat(new string[]
			{
				"update descricaoacao  set descricaoacao = '",
				list[1],
				"',dataprevista = '",
				list[2],
				"',datarealizada = '",
				list[3],
				"',previstapara = '",
				list[4],
				"',eficaz = '",
				list[5],
				"',verificadopor = '",
				list[6],
				"',dataverificadopor = '",
				list[7],
				"',observacoes = '",
				list[8],
				"',abertonovorelatorio = '",
				list[9],
				"',novorelatorio = '",
				list[10],
				"',datanovorelatorio = '",
				list[11],
				"'where idacao = '",
				list[0],
				"'"
			});
			Clipboard.SetText(query);
			this.db.SqlQuery(query);
			this.db.QueryRun();
		}

		private void update(List<acaoitem> _lista)
		{
			using (List<acaoitem>.Enumerator enumerator = _lista.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					List<string> list = enumerator.Current.RetornaUpdateAcao();
					string query = string.Concat(new string[]
					{
						"update descricaoacao  set descricaoacao = '",
						list[1],
						"',dataprevista = '",
						list[2],
						"',datarealizada = '",
						list[3],
						"',previstapara = '",
						list[4],
						"',eficaz = '",
						list[5],
						"',verificadopor = '",
						list[6],
						"',dataverificadopor = '",
						list[7],
						"',observacoes = '",
						list[8],
						"',abertonovorelatorio = '",
						list[9],
						"',novorelatorio = '",
						list[10],
						"',datanovorelatorio = '",
						list[11],
						"'where idacao = '",
						list[0],
						"'"
					});
					Clipboard.SetText(query);
					this.db.SqlQuery(query);
					this.db.QueryRun();
				}
			}
		}

		public void GravarToSQL()
		{
			this.db.SqlConnection();
			string idRNC = new buscar().M_peganumerornc();
			if (StoreRelatorio.GetRNCNumber() != idRNC)
			{
				StoreRelatorio.UpdateRNCID(idRNC);
				this.gravar.IDChanged = true;
			}
			List<string> queries = StoreRelatorio.GetSQLquery();
			for (int i = 0; i < queries.Count<string>(); i++)
			{
				if (i == 0)
				{
					string query = "insert into naoconformidade (idnc,descricaonc,emitentenc,datanc,setor,origemnc,tratamentonc,investicacaonc,disposicaonc,situacao, risco) values(" + queries[i];
					Clipboard.SetText(queries[i]);
					this.db.SqlQuery(query);
					this.db.QueryRun();
				}
				else
				{
					string query = this.insert(queries, i);
				}
			}
			this.db.closeConnection();
		}

		private string insert(List<string> queries, int i)
		{
			string query = "insert into descricaoacao values (" + queries[i] + ") ";
			Clipboard.SetText(queries[i]);
			this.db.SqlQuery(query);
			this.db.QueryRun();
			buscar expr_3F = new buscar();
			expr_3F.M_peganumerornc2();
			string numeroacao = expr_3F.m_pegaidacao();
			query = string.Concat(new string[]
			{
				"insert into naoconformidade_descricaoacao values ('",
				StoreRelatorio.GetRNCNumber(),
				"','",
				numeroacao,
				"')"
			});
			Clipboard.SetText(queries[i]);
			this.db.SqlQuery(query);
			this.db.QueryRun();
			return query;
		}

		private string insert(acaoitem _acaoitem)
		{
			string query = "insert into descricaoacao values (" + _acaoitem.descricaoacao() + ") ";
			Clipboard.SetText(query);
			this.db.SqlQuery(query);
			this.db.QueryRun();
			buscar expr_38 = new buscar();
			expr_38.M_peganumerornc2();
			string numeroacao = expr_38.m_pegaidacao();
			query = string.Concat(new string[]
			{
				"insert into naoconformidade_descricaoacao values ('",
				StoreRelatorio.GetRNCNumber(),
				"','",
				numeroacao,
				"')"
			});
			Clipboard.SetText(query);
			this.db.SqlQuery(query);
			this.db.QueryRun();
			return query;
		}
	}
}
