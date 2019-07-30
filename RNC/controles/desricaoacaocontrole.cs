using RNC.controles;
using RNC.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace RNC
{
	public class desricaoacaocontrole : UserControl
	{
		private acaoitem Acaoitem;

		private ConnectionClass db = new ConnectionClass();

		private buscar bc = new buscar();

		private acaoitem AcaoUsando;

		private List<acaoitem> ListAcoes = new List<acaoitem>();

		private IContainer components;

		private FlowLayoutPanel flowLayoutPanel1;

		private GroupBox gpDescricao;

		private CheckBox ckRealizada;

		private DateTimePicker dpDtRealizada;

		private DateTimePicker dpPrevista;

		private Label label8;

		private Label label4;

		private RichTextBox txtdescricao;

		private GroupBox gpVerificacao;

		private DateTimePicker dpPrevistaPara;

		private Label label10;

		private Label label9;

		private GroupBox gpEficiencia;

		private CheckBox ckeficaz;

		private Panel pnEficacia;

		private DateTimePicker dpNovoRelatorio;

		private DateTimePicker dpDTVerificada;

		private CheckBox cknovorelatorio;

		private Label label16;

		private RichTextBox txtObservacao;

		private Label label15;

		private Label label13;

		private Label label12;

		private Panel pnButtons;

		private Button btLimpar;

		public Button btGravar;

		private MaskedTextBox mskNRNC;

		private Label label1;

		private TextBox txtVerificadoPor;

		public previsaodeacao Objprevisaodeacao
		{
			get;
			set;
		}

		public desricaoacaocontrole(acaoitem _acaoitem)
		{
			this.InitializeComponent();
			this.AcaoUsando = _acaoitem;
			_acaoitem.datanovorelatorio.ToString("dd/MM/yyyy");
			this.RealizadaCKHandler();
			if ((_acaoitem.datanovorelatorio.ToString("dd/MM/yyyy") != "01/01/0001" && _acaoitem.dataverificadopor.ToString("dd/MM/yyyy") != "01/01/0001") || _acaoitem.descricao != null)
			{
				this.carregacao(this.AcaoUsando);
				return;
			}
			this.NewAcaoHandler(this.AcaoUsando);
		}

		private void NewAcaoHandler(acaoitem _acao)
		{
			this.txtdescricao.Text = _acao.descricao;
			this.dpPrevista.Value = DateTime.Now;
			this.pnButtons.Visible = true;
			this.dpDtRealizada.Visible = false;
			this.gpVerificacao.Visible = false;
			this.gpEficiencia.Visible = false;
			this.pnEficacia.Visible = false;
			this.dpDtRealizada.Text = "";
			this.dpPrevistaPara.Text = "";
			this.txtObservacao.Text = _acao.observacoes;
			this.ckeficaz.Checked = Convert.ToBoolean(_acao.eficaz);
			this.txtVerificadoPor.Text = _acao.verificadopor;
			this.dpDTVerificada.Text = "";
			this.cknovorelatorio.Checked = Convert.ToBoolean(_acao.abertonovorelatorio);
			this.mskNRNC.Visible = false;
			this.dpNovoRelatorio.Visible = false;
			this.label12.Visible = false;
			this.label1.Visible = false;
		}

		private void carregacao(acaoitem _acao)
		{
			this.txtdescricao.Text = _acao.descricao;
			this.dpPrevista.Value = _acao.prevista;
			if (_acao.realizada.ToString("dd/MM/yyyy") != "01/01/0001")
			{
				this.dpDtRealizada.Value = _acao.realizada;
				this.ckRealizada.Checked = true;
				this.dpPrevistaPara.Value = _acao.previstapara;
				this.ckeficaz.Checked = Convert.ToBoolean(_acao.eficaz);
				if (this.ckeficaz.Checked)
				{
					this.txtVerificadoPor.Text = _acao.verificadopor;
					this.dpDTVerificada.Value = _acao.dataverificadopor;
				}
				this.cknovorelatorio.Checked = Convert.ToBoolean(_acao.abertonovorelatorio);
				if (this.cknovorelatorio.Checked)
				{
					this.mskNRNC.Text = _acao.novorelatorio;
				}
				this.txtObservacao.Text = _acao.observacoes;
			}
			else
			{
				this.ckRealizada.Checked = false;
			}
			if (this.cknovorelatorio.Checked)
			{
				this.mskNRNC.Visible = true;
				this.mskNRNC.Text = _acao.novorelatorio;
				this.dpNovoRelatorio.Visible = true;
				this.label12.Visible = true;
				this.label1.Visible = true;
				this.dpNovoRelatorio.Value = _acao.datanovorelatorio;
				return;
			}
			this.mskNRNC.Visible = false;
			this.dpNovoRelatorio.Visible = false;
			this.label12.Visible = false;
			this.label1.Visible = false;
		}

		public void m_transformacaoitem(acaoitem _acao)
		{
			try
			{
				_acao.descricao = this.txtdescricao.Text;
				_acao.prevista = this.dpPrevista.Value;
				if (this.ckRealizada.Checked)
				{
					_acao.realizada = this.dpDtRealizada.Value;
					_acao.previstapara = this.dpPrevistaPara.Value;
				}
				_acao.eficaz = Convert.ToBoolean(this.ckeficaz.Checked);
				if (this.ckeficaz.Checked)
				{
					_acao.verificadopor = this.txtVerificadoPor.Text;
					_acao.dataverificadopor = this.dpDTVerificada.Value;
					_acao.observacoes = this.txtObservacao.Text;
					_acao.novorelatorio = this.mskNRNC.Text;
					_acao.abertonovorelatorio = Convert.ToBoolean(this.cknovorelatorio.Checked);
					if (this.cknovorelatorio.Checked)
					{
						_acao.datanovorelatorio = this.dpNovoRelatorio.Value;
					}
				}
			}
			catch (WrongDatetime arg_EE_0)
			{
				MessageBox.Show(arg_EE_0.ToString());
			}
			catch (BlankFieldEx arg_FB_0)
			{
				MessageBox.Show(arg_FB_0.ToString());
			}
		}

		private static void CheckDate(string[] _ToText)
		{
			string format = "dd/MM/yyyy";
			CultureInfo formatdate = new CultureInfo("pt-BR");
			for (int i = 0; i < _ToText.Length; i++)
			{
				DateTime datetime;
				if (!DateTime.TryParseExact(_ToText[i], format, formatdate, DateTimeStyles.AssumeLocal, out datetime))
				{
					throw new WrongDatetime("Data incorreta");
				}
			}
		}

		private static void CheckDate(DateTime _date)
		{
			new CultureInfo("pt-BR");
		}

		private static void CheckBlank(string[] _ToText)
		{
			for (int i = 0; i < _ToText.Length; i++)
			{
				if (!(_ToText[i] != ""))
				{
					throw new BlankFieldEx("Algum campo obrigatorio esta em branco");
				}
			}
		}

		public void button1_Click(object sender, EventArgs e)
		{
		}

		private void ckeficaz_CheckedChanged(object sender, EventArgs e)
		{
			if (this.ckeficaz.Checked)
			{
				this.pnEficacia.Visible = true;
				return;
			}
			this.pnEficacia.Visible = false;
		}

		private void cbRealizada_CheckedChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			this.RealizadaCKHandler();
		}

		private void RealizadaCKHandler()
		{
			if (this.ckRealizada.Checked)
			{
				this.dpDtRealizada.Visible = true;
				this.dpPrevistaPara.Visible = true;
				this.dpDTVerificada.Visible = true;
				this.gpVerificacao.Visible = true;
				this.gpEficiencia.Visible = true;
				this.pnEficacia.Visible = false;
				return;
			}
			this.ckeficaz.Checked = false;
			this.dpDtRealizada.Visible = false;
			this.dpPrevistaPara.Visible = false;
			this.dpDTVerificada.Visible = false;
			this.gpVerificacao.Visible = false;
			this.gpEficiencia.Visible = false;
		}

		private void ckeficaz_CheckedChanged_1(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			if (this.ckeficaz.Checked)
			{
				this.dpDTVerificada.Visible = true;
				this.gpVerificacao.Visible = true;
				this.gpEficiencia.Visible = true;
				this.pnEficacia.Visible = true;
				return;
			}
			this.pnEficacia.Visible = false;
		}

		private void cknovorelatorio_CheckedChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			if (this.cknovorelatorio.Checked)
			{
				this.label12.Visible = true;
				this.dpNovoRelatorio.Visible = true;
				this.label1.Visible = true;
				this.mskNRNC.Visible = true;
				return;
			}
			this.label12.Visible = false;
			this.dpNovoRelatorio.Visible = false;
			this.label1.Visible = false;
			this.mskNRNC.Visible = false;
		}

		private void btGravar_Click(object sender, EventArgs e)
		{
			this.m_transformacaoitem(this.AcaoUsando);
			List<acaoitem> listaToReplace = StoreRelatorio.GetList();
			try
			{
				if (listaToReplace.Count<acaoitem>() == 0)
				{
					this.AcaoUsando.id = 1;
					listaToReplace.Add(this.AcaoUsando);
				}
				else if (listaToReplace.Count<acaoitem>() > 0)
				{
					acaoitem aux = listaToReplace.Last<acaoitem>();
					for (int i = 0; i < listaToReplace.Count<acaoitem>(); i++)
					{
						if (this.AcaoUsando.id == 0)
						{
							this.AcaoUsando.id = aux.id + 1;
							listaToReplace.Add(this.AcaoUsando);
							break;
						}
						if (listaToReplace[i].id == this.AcaoUsando.id)
						{
							listaToReplace[listaToReplace.IndexOf(listaToReplace[i])] = this.AcaoUsando;
						}
					}
				}
				MessageBox.Show("Acao gravado com sucesso, lembre-se é nescessario salvar o relatorio");
				StoreRelatorio.SetList(listaToReplace);
				this.btGravar.Enabled = false;
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void txtdescricao_TextChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			if (this.txtdescricao.Text.Length > 9)
			{
				this.Objprevisaodeacao.lbDescri.Text = this.txtdescricao.Text.Substring(0, 9) + "...";
			}
			else
			{
				this.Objprevisaodeacao.lbDescri.Text = this.txtdescricao.Text;
			}
			if (this.txtdescricao.Text.Contains("Corretiva"))
			{
				this.Objprevisaodeacao.lbTipo.Text = "Corretiva";
				return;
			}
			if (this.txtdescricao.Text.Contains("Preventiva"))
			{
				this.Objprevisaodeacao.lbTipo.Text = "Preventiva";
				return;
			}
			if (this.txtdescricao.Text.Contains("Educativa"))
			{
				this.Objprevisaodeacao.lbTipo.Text = "Educativa";
				return;
			}
			this.Objprevisaodeacao.lbTipo.Text = "Escreva tipo";
		}

		private void desricaoacaocontrole_Load(object sender, EventArgs e)
		{
			if (this.Objprevisaodeacao != null)
			{
				this.Objprevisaodeacao.lbData.Text = this.dpPrevista.Value.ToString("dd/MM/yyyy");
			}
		}

		private void dpPrevista_ValueChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			if (this.Objprevisaodeacao != null)
			{
				this.Objprevisaodeacao.lbData.Text = this.dpPrevista.Value.ToString("dd/MM/yyyy");
			}
		}

		private void btLimpar_Click(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
			this.txtdescricao.Text = null;
			this.dpPrevista.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.txtObservacao.Text = null;
			this.ckRealizada.Checked = false;
			this.dpPrevistaPara.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.ckeficaz.Checked = false;
			this.txtVerificadoPor.Text = null;
			this.dpDTVerificada.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.cknovorelatorio.Checked = false;
			this.dpNovoRelatorio.Text = DateTime.Now.ToString("dd/MM/yyyy");
			this.mskNRNC.Text = null;
		}

		private void dpDtRealizada_ValueChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
		}

		private void dpPrevistaPara_ValueChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
		}

		private void txtVerificadoPor_TextChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
		}

		private void dpDTVerificada_ValueChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
		}

		private void mskNRNC_TextChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
		}

		private void txtObservacao_TextChanged(object sender, EventArgs e)
		{
			this.btGravar.Enabled = true;
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
			this.flowLayoutPanel1 = new FlowLayoutPanel();
			this.gpDescricao = new GroupBox();
			this.ckRealizada = new CheckBox();
			this.dpDtRealizada = new DateTimePicker();
			this.dpPrevista = new DateTimePicker();
			this.label8 = new Label();
			this.label4 = new Label();
			this.txtdescricao = new RichTextBox();
			this.gpVerificacao = new GroupBox();
			this.dpPrevistaPara = new DateTimePicker();
			this.label10 = new Label();
			this.label9 = new Label();
			this.gpEficiencia = new GroupBox();
			this.ckeficaz = new CheckBox();
			this.pnEficacia = new Panel();
			this.mskNRNC = new MaskedTextBox();
			this.label1 = new Label();
			this.dpNovoRelatorio = new DateTimePicker();
			this.dpDTVerificada = new DateTimePicker();
			this.txtVerificadoPor = new TextBox();
			this.cknovorelatorio = new CheckBox();
			this.label16 = new Label();
			this.txtObservacao = new RichTextBox();
			this.label15 = new Label();
			this.label13 = new Label();
			this.label12 = new Label();
			this.pnButtons = new Panel();
			this.btLimpar = new Button();
			this.btGravar = new Button();
			this.flowLayoutPanel1.SuspendLayout();
			this.gpDescricao.SuspendLayout();
			this.gpVerificacao.SuspendLayout();
			this.gpEficiencia.SuspendLayout();
			this.pnEficacia.SuspendLayout();
			this.pnButtons.SuspendLayout();
			base.SuspendLayout();
			this.flowLayoutPanel1.Controls.Add(this.gpDescricao);
			this.flowLayoutPanel1.Controls.Add(this.gpVerificacao);
			this.flowLayoutPanel1.Controls.Add(this.gpEficiencia);
			this.flowLayoutPanel1.Controls.Add(this.pnButtons);
			this.flowLayoutPanel1.Dock = DockStyle.Fill;
			this.flowLayoutPanel1.Location = new Point(0, 0);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new Size(756, 312);
			this.flowLayoutPanel1.TabIndex = 0;
			this.gpDescricao.Controls.Add(this.ckRealizada);
			this.gpDescricao.Controls.Add(this.dpDtRealizada);
			this.gpDescricao.Controls.Add(this.dpPrevista);
			this.gpDescricao.Controls.Add(this.label8);
			this.gpDescricao.Controls.Add(this.label4);
			this.gpDescricao.Controls.Add(this.txtdescricao);
			this.gpDescricao.Dock = DockStyle.Top;
			this.gpDescricao.Location = new Point(3, 3);
			this.gpDescricao.Name = "gpDescricao";
			this.gpDescricao.Size = new Size(750, 84);
			this.gpDescricao.TabIndex = 15;
			this.gpDescricao.TabStop = false;
			this.gpDescricao.Text = "Descrição da Ação (Corretiva, Preventiva ou Educativa)";
			this.ckRealizada.AutoSize = true;
			this.ckRealizada.Location = new Point(534, 50);
			this.ckRealizada.Name = "ckRealizada";
			this.ckRealizada.RightToLeft = RightToLeft.Yes;
			this.ckRealizada.Size = new Size(76, 17);
			this.ckRealizada.TabIndex = 24;
			this.ckRealizada.Text = ":Realizada";
			this.ckRealizada.UseVisualStyleBackColor = true;
			this.ckRealizada.CheckedChanged += new EventHandler(this.cbRealizada_CheckedChanged);
			this.dpDtRealizada.Format = DateTimePickerFormat.Short;
			this.dpDtRealizada.Location = new Point(615, 47);
			this.dpDtRealizada.Name = "dpDtRealizada";
			this.dpDtRealizada.Size = new Size(99, 20);
			this.dpDtRealizada.TabIndex = 14;
			this.dpDtRealizada.ValueChanged += new EventHandler(this.dpDtRealizada_ValueChanged);
			this.dpPrevista.Format = DateTimePickerFormat.Short;
			this.dpPrevista.Location = new Point(594, 24);
			this.dpPrevista.Name = "dpPrevista";
			this.dpPrevista.Size = new Size(99, 20);
			this.dpPrevista.TabIndex = 13;
			this.dpPrevista.ValueChanged += new EventHandler(this.dpPrevista_ValueChanged);
			this.label8.AutoSize = true;
			this.label8.Location = new Point(569, 0);
			this.label8.Name = "label8";
			this.label8.Size = new Size(126, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "Data de Implementação: ";
			this.label4.AutoSize = true;
			this.label4.Location = new Point(539, 22);
			this.label4.Name = "label4";
			this.label4.Padding = new Padding(4, 3, 0, 0);
			this.label4.Size = new Size(55, 16);
			this.label4.TabIndex = 9;
			this.label4.Text = "Prevista: ";
			this.txtdescricao.Location = new Point(3, 19);
			this.txtdescricao.Name = "txtdescricao";
			this.txtdescricao.Size = new Size(438, 59);
			this.txtdescricao.TabIndex = 0;
			this.txtdescricao.Text = "";
			this.txtdescricao.TextChanged += new EventHandler(this.txtdescricao_TextChanged);
			this.gpVerificacao.Controls.Add(this.dpPrevistaPara);
			this.gpVerificacao.Controls.Add(this.label10);
			this.gpVerificacao.Controls.Add(this.label9);
			this.gpVerificacao.Dock = DockStyle.Top;
			this.gpVerificacao.Location = new Point(3, 93);
			this.gpVerificacao.Name = "gpVerificacao";
			this.gpVerificacao.Size = new Size(753, 37);
			this.gpVerificacao.TabIndex = 16;
			this.gpVerificacao.TabStop = false;
			this.gpVerificacao.Text = "Verificação da Eficácia das Ações Implementadas";
			this.dpPrevistaPara.Format = DateTimePickerFormat.Short;
			this.dpPrevistaPara.Location = new Point(75, 14);
			this.dpPrevistaPara.Name = "dpPrevistaPara";
			this.dpPrevistaPara.Size = new Size(99, 20);
			this.dpPrevistaPara.TabIndex = 21;
			this.dpPrevistaPara.ValueChanged += new EventHandler(this.dpPrevistaPara_ValueChanged);
			this.label10.AutoSize = true;
			this.label10.Dock = DockStyle.Left;
			this.label10.Location = new Point(3, 16);
			this.label10.Name = "label10";
			this.label10.Size = new Size(75, 13);
			this.label10.TabIndex = 1;
			this.label10.Text = "Prevista para: \r\n";
			this.label9.AutoSize = true;
			this.label9.Dock = DockStyle.Left;
			this.label9.Location = new Point(3, 16);
			this.label9.Name = "label9";
			this.label9.Size = new Size(0, 13);
			this.label9.TabIndex = 0;
			this.gpEficiencia.Controls.Add(this.ckeficaz);
			this.gpEficiencia.Controls.Add(this.pnEficacia);
			this.gpEficiencia.Location = new Point(3, 136);
			this.gpEficiencia.Name = "gpEficiencia";
			this.gpEficiencia.Size = new Size(750, 140);
			this.gpEficiencia.TabIndex = 25;
			this.gpEficiencia.TabStop = false;
			this.gpEficiencia.Text = "Eficiencia da ação";
			this.ckeficaz.AutoSize = true;
			this.ckeficaz.Location = new Point(6, 19);
			this.ckeficaz.Name = "ckeficaz";
			this.ckeficaz.RightToLeft = RightToLeft.Yes;
			this.ckeficaz.Size = new Size(64, 17);
			this.ckeficaz.TabIndex = 31;
			this.ckeficaz.Text = "? Eficaz";
			this.ckeficaz.UseVisualStyleBackColor = true;
			this.ckeficaz.CheckedChanged += new EventHandler(this.ckeficaz_CheckedChanged_1);
			this.pnEficacia.Controls.Add(this.mskNRNC);
			this.pnEficacia.Controls.Add(this.label1);
			this.pnEficacia.Controls.Add(this.dpNovoRelatorio);
			this.pnEficacia.Controls.Add(this.dpDTVerificada);
			this.pnEficacia.Controls.Add(this.txtVerificadoPor);
			this.pnEficacia.Controls.Add(this.cknovorelatorio);
			this.pnEficacia.Controls.Add(this.label16);
			this.pnEficacia.Controls.Add(this.txtObservacao);
			this.pnEficacia.Controls.Add(this.label15);
			this.pnEficacia.Controls.Add(this.label13);
			this.pnEficacia.Controls.Add(this.label12);
			this.pnEficacia.Dock = DockStyle.Bottom;
			this.pnEficacia.Location = new Point(3, 47);
			this.pnEficacia.Name = "pnEficacia";
			this.pnEficacia.Size = new Size(744, 90);
			this.pnEficacia.TabIndex = 36;
			this.mskNRNC.Location = new Point(326, 43);
			this.mskNRNC.Mask = "999-9999";
			this.mskNRNC.Name = "mskNRNC";
			this.mskNRNC.Size = new Size(66, 20);
			this.mskNRNC.TabIndex = 48;
			this.mskNRNC.TextChanged += new EventHandler(this.mskNRNC_TextChanged);
			this.label1.AutoSize = true;
			this.label1.Location = new Point(305, 47);
			this.label1.Name = "label1";
			this.label1.Size = new Size(22, 13);
			this.label1.TabIndex = 47;
			this.label1.Text = "Nº:";
			this.dpNovoRelatorio.Format = DateTimePickerFormat.Short;
			this.dpNovoRelatorio.Location = new Point(196, 44);
			this.dpNovoRelatorio.Name = "dpNovoRelatorio";
			this.dpNovoRelatorio.Size = new Size(99, 20);
			this.dpNovoRelatorio.TabIndex = 46;
			this.dpDTVerificada.Format = DateTimePickerFormat.Short;
			this.dpDTVerificada.Location = new Point(288, 6);
			this.dpDTVerificada.Name = "dpDTVerificada";
			this.dpDTVerificada.Size = new Size(99, 20);
			this.dpDTVerificada.TabIndex = 45;
			this.dpDTVerificada.ValueChanged += new EventHandler(this.dpDTVerificada_ValueChanged);
			this.txtVerificadoPor.Location = new Point(91, 3);
			this.txtVerificadoPor.Name = "txtVerificadoPor";
			this.txtVerificadoPor.Size = new Size(129, 20);
			this.txtVerificadoPor.TabIndex = 49;
			this.txtVerificadoPor.TextChanged += new EventHandler(this.txtVerificadoPor_TextChanged);
			this.cknovorelatorio.AutoSize = true;
			this.cknovorelatorio.Location = new Point(10, 47);
			this.cknovorelatorio.Name = "cknovorelatorio";
			this.cknovorelatorio.RightToLeft = RightToLeft.Yes;
			this.cknovorelatorio.Size = new Size(130, 17);
			this.cknovorelatorio.TabIndex = 43;
			this.cknovorelatorio.Text = "?Aberto novo relatório";
			this.cknovorelatorio.UseVisualStyleBackColor = true;
			this.cknovorelatorio.CheckedChanged += new EventHandler(this.cknovorelatorio_CheckedChanged);
			this.label16.AutoSize = true;
			this.label16.Location = new Point(259, 9);
			this.label16.Name = "label16";
			this.label16.Size = new Size(36, 13);
			this.label16.TabIndex = 42;
			this.label16.Text = "Data: ";
			this.txtObservacao.AcceptsTab = true;
			this.txtObservacao.Location = new Point(494, 7);
			this.txtObservacao.Name = "txtObservacao";
			this.txtObservacao.Size = new Size(221, 65);
			this.txtObservacao.TabIndex = 38;
			this.txtObservacao.Text = "";
			this.txtObservacao.TextChanged += new EventHandler(this.txtObservacao_TextChanged);
			this.label15.AutoSize = true;
			this.label15.Location = new Point(11, 9);
			this.label15.Name = "label15";
			this.label15.Size = new Size(75, 13);
			this.label15.TabIndex = 39;
			this.label15.Text = "Verificado por:";
			this.label13.AutoSize = true;
			this.label13.Location = new Point(415, 10);
			this.label13.Name = "label13";
			this.label13.Size = new Size(73, 13);
			this.label13.TabIndex = 37;
			this.label13.Text = "Observações:";
			this.label12.AutoSize = true;
			this.label12.Location = new Point(159, 47);
			this.label12.Name = "label12";
			this.label12.Size = new Size(36, 13);
			this.label12.TabIndex = 36;
			this.label12.Text = "Data: ";
			this.label12.Visible = false;
			this.pnButtons.Controls.Add(this.btLimpar);
			this.pnButtons.Controls.Add(this.btGravar);
			this.pnButtons.Dock = DockStyle.Bottom;
			this.pnButtons.Location = new Point(3, 282);
			this.pnButtons.Name = "pnButtons";
			this.pnButtons.Size = new Size(744, 26);
			this.pnButtons.TabIndex = 48;
			this.btLimpar.Location = new Point(119, 3);
			this.btLimpar.Name = "btLimpar";
			this.btLimpar.Size = new Size(75, 23);
			this.btLimpar.TabIndex = 46;
			this.btLimpar.Text = "Limpar";
			this.btLimpar.UseVisualStyleBackColor = true;
			this.btLimpar.Click += new EventHandler(this.btLimpar_Click);
			this.btGravar.Location = new Point(3, 3);
			this.btGravar.Name = "btGravar";
			this.btGravar.Size = new Size(75, 23);
			this.btGravar.TabIndex = 45;
			this.btGravar.Text = "Salvar";
			this.btGravar.UseVisualStyleBackColor = true;
			this.btGravar.Click += new EventHandler(this.btGravar_Click);
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.flowLayoutPanel1);
			base.Name = "desricaoacaocontrole";
			base.Size = new Size(756, 312);
			base.Load += new EventHandler(this.desricaoacaocontrole_Load);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.gpDescricao.ResumeLayout(false);
			this.gpDescricao.PerformLayout();
			this.gpVerificacao.ResumeLayout(false);
			this.gpVerificacao.PerformLayout();
			this.gpEficiencia.ResumeLayout(false);
			this.gpEficiencia.PerformLayout();
			this.pnEficacia.ResumeLayout(false);
			this.pnEficacia.PerformLayout();
			this.pnButtons.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
