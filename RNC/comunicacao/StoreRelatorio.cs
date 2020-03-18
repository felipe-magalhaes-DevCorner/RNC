using RNC.controles;
using System.Collections.Generic;

namespace RNC
{
	public static class StoreRelatorio
	{
		public static relatorio RelatorioUsing
		{
			get;
			set;
		}

		public static cadastrocontrol CadastroUsing
		{
			get;
			set;
		}

		public static relatorio relatorioBack
		{
			get;
			set;
		}

		public static string loggedname
		{
			get;
			set;
		}

		public static colecaodeacaoitem ColecaoBase
		{
			get;
			set;
		}

		public static void SetRelatorio(relatorio relatorio)
		{
			StoreRelatorio.RelatorioUsing = relatorio;
		}

		public static relatorio GetRelatorio()
		{
			return StoreRelatorio.RelatorioUsing;
		}

		public static colecaodeacaoitem GetColecao()
		{
			return StoreRelatorio.RelatorioUsing.ReturnColecao();
		}

		public static void addAcao(acaoitem acao)
		{
			StoreRelatorio.RelatorioUsing.AddColecao(acao);
		}

		public static acaoitem getAcao(int index)
		{
			return StoreRelatorio.RelatorioUsing.getAcaoByIndex(index);
		}

		public static List<string> GetUpdateInfo()
		{
			return StoreRelatorio.RelatorioUsing.RetornaUpdate();
		}

		public static List<acaoitem> GetList()
		{
			return StoreRelatorio.RelatorioUsing.GetList();
		}

		public static cadastrocontrol GetCadastro()
		{
			return StoreRelatorio.CadastroUsing;
		}

		public static void SetList(List<acaoitem> lista)
		{
			StoreRelatorio.RelatorioUsing.ReturnColecao().SetList(lista);
		}

		public static void storeRelatorioConsulta(relatorio relatorio)
		{
			StoreRelatorio.relatorioBack = relatorio;
		}

		public static relatorio GetRelatorioConsulta()
		{
			return StoreRelatorio.relatorioBack;
		}

		public static void UpdateRNCID(string idrnc)
		{
			StoreRelatorio.RelatorioUsing.UpdateID(idrnc);
		}

		public static string GetRNCNumber()
		{
			return StoreRelatorio.RelatorioUsing.RNCNumber();
		}

		public static List<string> GetSQLquery()
		{
			return StoreRelatorio.RelatorioUsing.GetInformation();
		}

		public static void ClearRelatorio()
		{
			StoreRelatorio.RelatorioUsing = null;
			new colecaodeacaoitem().ClearAcoes();
		}


	}
}