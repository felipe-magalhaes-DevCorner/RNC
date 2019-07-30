using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace RNC.controles
{
	public class previsaodeacao : UserControl
	{
		private enum Colorsenum
		{
			light,
			main,
			dark
		}

		private int index = 1;

		private ConnectionClass db = new ConnectionClass();

		private buscar bc = new buscar();

		private Color light = Color.FromArgb(79, 90, 176);

		private Color main = Color.FromArgb(21, 49, 128);

		private Color dark = Color.FromArgb(0, 12, 83);

		private Random random = new Random();

		private IContainer components;

		private FlowLayoutPanel flowLayoutPanel1;

		public Label lbDescri;

		public Label lbTipo;

		public Label lbData;

		public Panel pncoracao;

		private static FlowLayoutPanel panelOrigem
		{
			get;
			set;
		}

		private static Panel Displaypanel
		{
			get;
			set;
		}

		public Panel Pncontrol
		{
			get;
			set;
		}

		private acaoitem AcaoUsed
		{
			get;
			set;
		}

		public previsaodeacao(acaoitem _acao)
		{
			this.InitializeComponent();
			this.lbData.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.AcaoUsed = _acao;
			if (this.AcaoUsed.descricao != null)
			{
				if (this.AcaoUsed.descricao.Contains("Corretiva"))
				{
					this.lbTipo.Text = "Corretiva";
				}
				else if (this.AcaoUsed.descricao.Contains("Preventiva"))
				{
					this.lbTipo.Text = "Preventiva";
				}
				else if (this.AcaoUsed.descricao.Contains("Educativa"))
				{
					this.lbTipo.Text = "Educativa";
				}
				else
				{
					this.lbTipo.Text = "Escreva tipo";
				}
				if (this.AcaoUsed.prevista.ToString("dd/MM/yyyy") == "01/01/0001")
				{
					this.lbData.Text = DateTime.Now.ToString("dd/MM/yyyy");
				}
				else
				{
					this.lbData.Text = this.AcaoUsed.prevista.ToString("dd/MM/yyyy");
				}
				if (this.AcaoUsed.descricao.Length < 20)
				{
					this.lbDescri.Text = this.AcaoUsed.descricao;
					return;
				}
				this.lbDescri.Text = this.AcaoUsed.descricao.Substring(0, 20) + "...";
			}
		}

		public static void M_setPanel(Panel P_displaypanel)
		{
			previsaodeacao.Displaypanel = P_displaypanel;
		}

		public void setOrigenPanel(FlowLayoutPanel _origenPanel)
		{
			previsaodeacao.panelOrigem = _origenPanel;
		}

		public void M_setpainel(Panel _panel)
		{
			previsaodeacao.Displaypanel = _panel;
		}

		public Panel M_pegarpainel()
		{
			return this.Pncontrol;
		}

		private void previsaodeacao_Click(object sender, EventArgs e)
		{
			previsaodeacao.Displaypanel.Controls.Clear();
			desricaoacaocontrole descricao = new desricaoacaocontrole(this.AcaoUsed);
			descricao.Objprevisaodeacao = this;
			previsaodeacao.Displaypanel.Controls.Add(descricao);
		}

		private void previsaodeacao_Load(object sender, EventArgs e)
		{
			int arg_0F_0 = previsaodeacao.panelOrigem.Controls.Count;
		}

		public void teste()
		{
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.lbDescri = new Label();
			this.lbTipo = new Label();
			this.lbData = new Label();
			this.pncoracao = new Panel();
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			base.SuspendLayout();
			this.lbDescri.AutoSize = true;
			this.lbDescri.Location = new Point(38, 6);
			this.lbDescri.Name = "lbDescri";
			this.lbDescri.Size = new Size(79, 13);
			this.lbDescri.TabIndex = 0;
			this.lbDescri.Text = "Ações exemplo";
			this.lbDescri.Click += new EventHandler(this.previsaodeacao_Click);
			this.lbTipo.AutoSize = true;
			this.lbTipo.ForeColor = SystemColors.HotTrack;
			this.lbTipo.Location = new Point(58, 23);
			this.lbTipo.Name = "lbTipo";
			this.lbTipo.Size = new Size(37, 13);
			this.lbTipo.TabIndex = 1;
			this.lbTipo.Text = "Tipo...";
			this.lbTipo.Click += new EventHandler(this.previsaodeacao_Click);
			this.lbData.AutoSize = true;
			this.lbData.Font = new Font("Microsoft Sans Serif", 8.25f, FontStyle.Bold, GraphicsUnit.Point, 0);
			this.lbData.ForeColor = Color.DarkBlue;
			this.lbData.Location = new Point(121, 42);
			this.lbData.Name = "lbData";
			this.lbData.Size = new Size(75, 13);
			this.lbData.TabIndex = 3;
			this.lbData.Text = "19/04/2018";
			this.lbData.Click += new EventHandler(this.previsaodeacao_Click);
			this.pncoracao.BackColor = Color.BlanchedAlmond;
			this.pncoracao.Dock = DockStyle.Left;
			this.pncoracao.Location = new Point(0, 0);
			this.pncoracao.Name = "pncoracao";
			this.pncoracao.Size = new Size(32, 58);
			this.pncoracao.TabIndex = 4;
			this.pncoracao.Click += new EventHandler(this.previsaodeacao_Click);
			this.flowLayoutPanel1.BackColor = Color.Beige;
			this.flowLayoutPanel1.Dock = DockStyle.Top;
			this.flowLayoutPanel1.Location = new Point(32, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new Size(166, 3);
			this.flowLayoutPanel1.TabIndex = 5;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.BorderStyle = BorderStyle.FixedSingle;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.pncoracao);
			base.Controls.Add(this.lbData);
			base.Controls.Add(this.lbTipo);
			base.Controls.Add(this.lbDescri);
			base.Name = "previsaodeacao";
			base.Size = new Size(198, 58);
			base.Load += new EventHandler(this.previsaodeacao_Load);
			base.Click += new EventHandler(this.previsaodeacao_Click);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
