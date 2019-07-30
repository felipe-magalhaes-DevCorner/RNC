using RNC.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace RNC
{
	internal class connectionclassgmn
	{
		private SqlConnection _conn;

		private SqlCommand _cmd;

		private SqlDataReader _datareader;

		private SqlDataAdapter _datadapter;

		private DataTable _dt;

		public void SqlConnection()
		{
			this._conn = new SqlConnection("Data Source=192.168.0.11;Initial Catalog=GMN;Integrated Security=False;User ID=sa;Password=n3fr0d@t@;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
			try
			{
				this._conn.Open();
				if (this._conn != null && this._conn.State == ConnectionState.Closed)
				{
					throw new ConnectionError("Sem comunicação com o banco de dados!");
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		public void SqlQuery(string pQueryText)
		{
			this._cmd = new SqlCommand(pQueryText, this._conn);
		}

		public DataTable ReturnDT()
		{
			this._datadapter = new SqlDataAdapter(this._cmd);
			this._dt = new DataTable();
			this._datadapter.Fill(this._dt);
			return this._dt;
		}

		public SqlDataReader SingleCellReader()
		{
			this._datareader = this._cmd.ExecuteReader();
			return this._datareader;
		}

		public void QueryRun()
		{
			this._cmd.ExecuteNonQuery();
		}

		public void RunQueryList(List<string> _queries)
		{
			foreach (string query in _queries)
			{
				this._cmd = new SqlCommand(query, this._conn);
				this._cmd.ExecuteNonQuery();
			}
		}

		internal SqlDataReader QueryReader()
		{
			throw new NotImplementedException();
		}

		public void closeConnection()
		{
			this._conn.Close();
			this._conn.Dispose();
		}
	}
}
