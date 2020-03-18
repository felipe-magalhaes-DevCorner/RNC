using System;
using System.Collections.Generic;

namespace RNC
{
	public class relatorio
	{
		private string id
		{
			get;
			set;
		}

		private string descricao
		{
			get;
			set;
		}

		private string emitente
		{
			get;
			set;
		}

		private DateTime data
		{
			get;
			set;
		}

		private string setor
		{
			get;
			set;
		}

		private string origem
		{
			get;
			set;
		}

		private string tratamento
		{
			get;
			set;
		}

		private string investigacao
		{
			get;
			set;
		}

		private string disposicao
		{
			get;
			set;
		}

		private string status
		{
			get;
			set;
		}
		private string risco
		{
			get;
			set;
		}

		private colecaodeacaoitem Colecaodeacaoitem
		{
			get;
			set;
		}

		public relatorio(string id, string descricao, string emitente, DateTime data, string setor, string origem, string tratamento, string investigacao, string disposicao, string status, colecaodeacaoitem colecao, string risco)
		{
			this.id = id;
			this.descricao = descricao;
			this.emitente = emitente;
			this.data = data;
			this.setor = setor;
			this.origem = origem;
			this.tratamento = tratamento;
			this.investigacao = investigacao;
			this.disposicao = disposicao;
			this.status = status;
			this.Colecaodeacaoitem = colecao;
			this.risco = risco;
		}


		public List<string> GetRelatorioFields()
		{
			return new List<string>
			{
				this.id,
				this.descricao,
				this.emitente,
				this.data.ToString("dd/MM/yyyy"),
				this.setor,
				this.origem,
				this.tratamento,
				this.investigacao,
				this.disposicao,
				this.status,
				this.risco
			};
		}

		public void UpdateID(string _idRNC)
		{
			this.id = _idRNC;
		}

		public colecaodeacaoitem ReturnColecao()
		{
			return this.Colecaodeacaoitem;
		}

		public void setColecao(colecaodeacaoitem colecao)
		{
			this.Colecaodeacaoitem = colecao;
		}

		public string RNCNumber()
		{
			return this.id;
		}

		public void AddColecao(acaoitem _acao)
		{
			this.Colecaodeacaoitem.AddList(_acao);
		}

		public acaoitem getAcaoByIndex(int _index)
		{
			return this.Colecaodeacaoitem.GetAcaoByIndex(_index);
		}

		public List<acaoitem> GetList()
		{
			return this.Colecaodeacaoitem.GetList();
		}

		public List<string> GetInformation()
		{
			List<string> info = new List<string>();
			info.Add(string.Concat(new string[]
			{
				"'",
				this.id,
				"' , '",
				this.descricao,
				"' , '",
				this.emitente,
				"' , '",
				this.data.ToString("MM/dd/yyyy"),
				"' , '",
				this.setor,
				"' , '",
				this.origem,
				"' , '",
				this.tratamento,
				"' , '",
				this.investigacao,
				"' , '",
				this.disposicao,
				"' , '",
				this.status,
				"' , '",
				this.risco,
				"')"
			}));
			if (this.Colecaodeacaoitem.ListCount() > 0)
			{
				foreach (acaoitem acao in this.Colecaodeacaoitem.GetList())
				{
					info.Add(acao.descricaoacao());
				}
			}
			return info;
		}

		public List<string> RetornaUpdate()
		{
			return new List<string>
			{
				this.id,
				this.descricao,
				this.emitente,
				this.data.ToString("MM/dd/yyyy"),
				this.setor,
				this.origem,
				this.tratamento,
				this.investigacao,
				this.disposicao,
				this.status,
				this.risco
			};
		}
	}
}
