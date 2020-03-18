using System;
using System.Collections.Generic;

namespace RNC
{
	public class relatorio
	{
        private string id { get; set; }

        private string descricao { get; set; }

        private string emitente { get; set; }

        private DateTime data { get; set; }

        private string setor { get; set; }

        private string origem { get; set; }

        private string tratamento { get; set; }

        private string investigacao { get; set; }

        private string disposicao { get; set; }

        private string status { get; set; }

        private string risco { get; set; }

        private colecaodeacaoitem Colecaodeacaoitem { get; set; }
        public string GetDisposição => this.disposicao;
        public string GetTratamento => this.tratamento;

        public string GetDescrição() => this.descricao;
        public string GetStatus() => this.status;
        public colecaodeacaoitem ReturnColecao() => Colecaodeacaoitem;
        public string RNCNumber() => this.id;
        public DateTime GetDate() => this.data;
        public string GetOrigem() => this.origem;

        public void UpdateID(string _idRNC)
        {
            this.id = _idRNC;
        }




        public void setColecao(colecaodeacaoitem colecao)
        {
            this.Colecaodeacaoitem = colecao;
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
        public relatorio()
        {
            //dummy relatorio
        }

        public relatorio GenereteRelatorioDummy()
        {
            var relatorio = new relatorio();
            relatorio.id = "001-2020";
            relatorio.descricao = "We start by creating two PdfFont objects of the same family: Helvetica regular (line 5) and Helvetica bold (line 6). We create a Table object for which we define nine columns by defining a float array with nine elements (line 7). Each float defines the relative width of a column. The first column is four times as wide as the second column; the third column is three times as wide as the second column; and so on. We also define the width of the table relative to the available width of the page (line 8). In this case, the table will use 100% of the width of the page, minus the page margins.";
            relatorio.emitente = "Felipe Magalhães";
            relatorio.data = new DateTime(2020,03,05);
            relatorio.setor = "Informatica";
            relatorio.origem = "Area tecnica";
            relatorio.tratamento = "tratamento teste";
            relatorio.investigacao = "In this example, we add the annotation to a newly created page. There’s no 'Document' instance involved in this example. ISO-32000-2 defines 28 different annotation types, two of which are deprecated in PDF 2.0. With iText, you can add all of these annotation types to a PDF document, but in the context of this tutorial,we’ll only look at one more example before we move on to interactive forms. See figure 4.4.";
            relatorio.disposicao = "When text doesn’t fit into the available text area of an HTML form, that field can be resized. The content of a list field can be updated on the fly based on a query to the server. In short, an HTML form can be very dynamic. In the next example, we’re going to create an interactive form based on AcroForm technology. This technology was introduced in PDF 1.2 (1996) and allows you to populate a PDF document with form fields such as text fields, choices (combo box or list field), buttons (push buttons, check boxes and radio buttons), and signature fields. It’s tempting to compare a PDF form with a form in HTML, but that would be wrong. When text doesn’t fit into the available text area of an HTML form, that field can be resized. The content of a list field can be updated on the fly based on a query to the server. In short, an HTML form can be very dynamic.";
            relatorio.status = "Aberta";
            relatorio.risco = "Alto";
			var acaoitemteste = new acaoitem(01,"First row has one cell 100% entire table width Second row has first from the left cell width 50mm, and second 20mm and third 30mm which in total is 100% of table width Third row has first from the left cell width 30mm, and second 50mm and third 10mm which in total is 90% of table width", new DateTime(2020,03,05), new DateTime(2020,03,05), new DateTime(2020,03,05), true,"Felipe Magalhães",new DateTime(2020,03,05), "observação", true, "002-2030", new DateTime(2021,03,05));
            acaoitemteste.tipo = "Corretiva";
            var coleçãodeAcoes = new colecaodeacaoitem {acaoitemteste,acaoitemteste,acaoitemteste,acaoitemteste,acaoitemteste,acaoitemteste};
            relatorio.Colecaodeacaoitem = coleçãodeAcoes;

            return relatorio;

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






		public void AddColecao(acaoitem _acao)
		{
			this.Colecaodeacaoitem.AddList(_acao);
		}

		public acaoitem getAcaoByIndex(int _index) =>this.Colecaodeacaoitem.GetAcaoByIndex(_index);


		public List<acaoitem> GetList() => this.Colecaodeacaoitem.GetList();
        public string GetEmitente() => this.emitente;
		

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

        public string GetInvestigação() => this.investigacao;
        
    }
}
