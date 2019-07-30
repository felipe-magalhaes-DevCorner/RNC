using System.Collections.Generic;
using RNC.controles;

namespace RNC
{
    public static class StoreRelatorio
    {public static relatorio RelatorioUsing
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

		public static void SetRelatorio(relatorio _relatorio)
		{
			StoreRelatorio.RelatorioUsing = _relatorio;
		}

		public static relatorio GetRelatorio()
		{
			return StoreRelatorio.RelatorioUsing;
		}

		public static colecaodeacaoitem GetColecao()
		{
			return StoreRelatorio.RelatorioUsing.ReturnColecao();
		}

		public static void addAcao(acaoitem _acao)
		{
			StoreRelatorio.RelatorioUsing.AddColecao(_acao);
		}

		public static acaoitem getAcao(int _Index)
		{
			return StoreRelatorio.RelatorioUsing.getAcaoByIndex(_Index);
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

		public static void SetList(List<acaoitem> _lista)
		{
			StoreRelatorio.RelatorioUsing.ReturnColecao().SetList(_lista);
		}

		public static void storeRelatorioConsulta(relatorio _relatorio)
		{
			StoreRelatorio.relatorioBack = _relatorio;
		}

		public static relatorio GetRelatorioConsulta()
		{
			return StoreRelatorio.relatorioBack;
		}

		public static void UpdateRNCID(string _idrnc)
		{
			StoreRelatorio.RelatorioUsing.UpdateID(_idrnc);
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

		public static void setColecao(colecaodeacaoitem colecao)
		{
		}
    }
}