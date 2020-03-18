using RNC.controles;
using RNC.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
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
        private PictureBox pbFAQDescriçãoAção;
        private PictureBox pbFAQEficiencia;
        private PictureBox pbFAQObservaçãoAcao;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private RadioButton rbCorretiva;
        private TextBox txtVerificadoPor;
        private bool RNCfechada = false;

        public previsaodeacao Objprevisaodeacao
        {
            get;
            set;
        }

        public desricaoacaocontrole(acaoitem _acaoitem, bool fechada = false)
        {
            this.InitializeComponent();
            this.AcaoUsando = _acaoitem;
            this.RNCfechada = fechada;
            _acaoitem.datanovorelatorio.ToString("dd/MM/yyyy");
            this.RealizadaCKHandler();
            if (RNCfechada)
            {
                LockAllControllers(this.Controls);
                btGravar.Enabled = false;
            }
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

            foreach (Control contro in gpDescricao.Controls)
            {
                if (contro is RadioButton)
                {
                    var rb = (RadioButton)contro;
                    if (rb.Text == _acao.tipo.Trim())
                    {
                        rb.Checked = true;
                    }
                }
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

        public bool m_transformacaoitem(acaoitem _acao)
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
                var buttons = gpDescricao.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);

                if (buttons == null || buttons.Text == "")
                {


                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar se a ação é corretiva, educativa ou preventiva!");

                }
                else
                {
                    _acao.tipo = buttons.Text;
                }


                return true;
            }
            catch (WrongDatetime arg_EE_0)
            {
                MessageBox.Show(arg_EE_0.ToString());
                return false;
            }
            catch (BlankFieldEx arg_FB_0)
            {
                MessageBox.Show(arg_FB_0.ToString());
                return false;
            }
            catch (NoButtonSelected e)
            {
                MessageBox.Show(e.ToString());
                return false;
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
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }

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
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }

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
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
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
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
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
            try
            {
                if (this.m_transformacaoitem(this.AcaoUsando))
                {
                    List<acaoitem> listaToReplace = StoreRelatorio.GetList();


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

                    StoreRelatorio.SetList(listaToReplace);
                    this.btGravar.Enabled = false;
                    MessageBox.Show("Acao gravado com sucesso, lembre-se é nescessario salvar o relatorio");
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtdescricao_TextChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
            if (this.txtdescricao.Text.Length > 9)
            {
                this.Objprevisaodeacao.lbDescri.Text = this.txtdescricao.Text.Substring(0, 9) + "...";
            }
            else
            {
                this.Objprevisaodeacao.lbDescri.Text = this.txtdescricao.Text;
            }

        }

        private void desricaoacaocontrole_Load(object sender, EventArgs e)
        {
            if (this.Objprevisaodeacao != null)
            {
                this.Objprevisaodeacao.lbData.Text = this.dpPrevista.Value.ToString("dd/MM/yyyy");
                setLineFormat(1, 2, txtObservacao);
                setLineFormat(1, 2, txtdescricao);
            }

        }

        private void dpPrevista_ValueChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
            if (this.Objprevisaodeacao != null)
            {
                this.Objprevisaodeacao.lbData.Text = this.dpPrevista.Value.ToString("dd/MM/yyyy");
            }
        }

        private void btLimpar_Click(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
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
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
        }

        private void dpPrevistaPara_ValueChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
        }

        private void txtVerificadoPor_TextChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
        }

        private void dpDTVerificada_ValueChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
        }

        private void mskNRNC_TextChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
        }

        private void txtObservacao_TextChanged(object sender, EventArgs e)
        {
            this.btGravar.Enabled = true;
            if (RNCfechada)
            {
                this.btGravar.Enabled = false;
            }
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gpDescricao = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbCorretiva = new System.Windows.Forms.RadioButton();
            this.pbFAQDescriçãoAção = new System.Windows.Forms.PictureBox();
            this.ckRealizada = new System.Windows.Forms.CheckBox();
            this.dpDtRealizada = new System.Windows.Forms.DateTimePicker();
            this.dpPrevista = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtdescricao = new System.Windows.Forms.RichTextBox();
            this.gpVerificacao = new System.Windows.Forms.GroupBox();
            this.dpPrevistaPara = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.gpEficiencia = new System.Windows.Forms.GroupBox();
            this.pbFAQEficiencia = new System.Windows.Forms.PictureBox();
            this.ckeficaz = new System.Windows.Forms.CheckBox();
            this.pnEficacia = new System.Windows.Forms.Panel();
            this.pbFAQObservaçãoAcao = new System.Windows.Forms.PictureBox();
            this.mskNRNC = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dpNovoRelatorio = new System.Windows.Forms.DateTimePicker();
            this.dpDTVerificada = new System.Windows.Forms.DateTimePicker();
            this.txtVerificadoPor = new System.Windows.Forms.TextBox();
            this.cknovorelatorio = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.RichTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.pnButtons = new System.Windows.Forms.Panel();
            this.btLimpar = new System.Windows.Forms.Button();
            this.btGravar = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.gpDescricao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQDescriçãoAção)).BeginInit();
            this.gpVerificacao.SuspendLayout();
            this.gpEficiencia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQEficiencia)).BeginInit();
            this.pnEficacia.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQObservaçãoAcao)).BeginInit();
            this.pnButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.gpDescricao);
            this.flowLayoutPanel1.Controls.Add(this.gpVerificacao);
            this.flowLayoutPanel1.Controls.Add(this.gpEficiencia);
            this.flowLayoutPanel1.Controls.Add(this.pnButtons);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(756, 312);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gpDescricao
            // 
            this.gpDescricao.Controls.Add(this.radioButton2);
            this.gpDescricao.Controls.Add(this.radioButton1);
            this.gpDescricao.Controls.Add(this.rbCorretiva);
            this.gpDescricao.Controls.Add(this.pbFAQDescriçãoAção);
            this.gpDescricao.Controls.Add(this.ckRealizada);
            this.gpDescricao.Controls.Add(this.dpDtRealizada);
            this.gpDescricao.Controls.Add(this.dpPrevista);
            this.gpDescricao.Controls.Add(this.label8);
            this.gpDescricao.Controls.Add(this.label4);
            this.gpDescricao.Controls.Add(this.txtdescricao);
            this.gpDescricao.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpDescricao.Location = new System.Drawing.Point(3, 3);
            this.gpDescricao.Name = "gpDescricao";
            this.gpDescricao.Size = new System.Drawing.Size(750, 84);
            this.gpDescricao.TabIndex = 15;
            this.gpDescricao.TabStop = false;
            this.gpDescricao.Text = "Descrição da Ação";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(415, 61);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(73, 17);
            this.radioButton2.TabIndex = 28;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Educativa";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.rbCorretiva_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(415, 38);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(76, 17);
            this.radioButton1.TabIndex = 27;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Preventiva";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.rbCorretiva_CheckedChanged);
            // 
            // rbCorretiva
            // 
            this.rbCorretiva.AutoSize = true;
            this.rbCorretiva.Location = new System.Drawing.Point(415, 15);
            this.rbCorretiva.Name = "rbCorretiva";
            this.rbCorretiva.Size = new System.Drawing.Size(67, 17);
            this.rbCorretiva.TabIndex = 26;
            this.rbCorretiva.TabStop = true;
            this.rbCorretiva.Text = "Corretiva";
            this.rbCorretiva.UseVisualStyleBackColor = true;
            this.rbCorretiva.CheckedChanged += new System.EventHandler(this.rbCorretiva_CheckedChanged);
            // 
            // pbFAQDescriçãoAção
            // 
            this.pbFAQDescriçãoAção.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFAQDescriçãoAção.Image = global::RNC.Properties.Resources.faqs;
            this.pbFAQDescriçãoAção.Location = new System.Drawing.Point(731, 68);
            this.pbFAQDescriçãoAção.Name = "pbFAQDescriçãoAção";
            this.pbFAQDescriçãoAção.Size = new System.Drawing.Size(16, 16);
            this.pbFAQDescriçãoAção.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFAQDescriçãoAção.TabIndex = 25;
            this.pbFAQDescriçãoAção.TabStop = false;
            this.pbFAQDescriçãoAção.MouseHover += new System.EventHandler(this.pbFAQDescriçãoAção_MouseHover);
            // 
            // ckRealizada
            // 
            this.ckRealizada.AutoSize = true;
            this.ckRealizada.Location = new System.Drawing.Point(534, 50);
            this.ckRealizada.Name = "ckRealizada";
            this.ckRealizada.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckRealizada.Size = new System.Drawing.Size(76, 17);
            this.ckRealizada.TabIndex = 24;
            this.ckRealizada.Text = ":Realizada";
            this.ckRealizada.UseVisualStyleBackColor = true;
            this.ckRealizada.CheckedChanged += new System.EventHandler(this.cbRealizada_CheckedChanged);
            // 
            // dpDtRealizada
            // 
            this.dpDtRealizada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDtRealizada.Location = new System.Drawing.Point(615, 47);
            this.dpDtRealizada.Name = "dpDtRealizada";
            this.dpDtRealizada.Size = new System.Drawing.Size(99, 20);
            this.dpDtRealizada.TabIndex = 14;
            this.dpDtRealizada.ValueChanged += new System.EventHandler(this.dpDtRealizada_ValueChanged);
            // 
            // dpPrevista
            // 
            this.dpPrevista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpPrevista.Location = new System.Drawing.Point(594, 24);
            this.dpPrevista.Name = "dpPrevista";
            this.dpPrevista.Size = new System.Drawing.Size(99, 20);
            this.dpPrevista.TabIndex = 13;
            this.dpPrevista.ValueChanged += new System.EventHandler(this.dpPrevista_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(569, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Data de Implementação: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(539, 22);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Prevista: ";
            // 
            // txtdescricao
            // 
            this.txtdescricao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescricao.Location = new System.Drawing.Point(3, 19);
            this.txtdescricao.Name = "txtdescricao";
            this.txtdescricao.Size = new System.Drawing.Size(406, 59);
            this.txtdescricao.TabIndex = 0;
            this.txtdescricao.Text = "";
            this.txtdescricao.TextChanged += new System.EventHandler(this.txtdescricao_TextChanged);
            // 
            // gpVerificacao
            // 
            this.gpVerificacao.Controls.Add(this.dpPrevistaPara);
            this.gpVerificacao.Controls.Add(this.label10);
            this.gpVerificacao.Controls.Add(this.label9);
            this.gpVerificacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpVerificacao.Location = new System.Drawing.Point(3, 93);
            this.gpVerificacao.Name = "gpVerificacao";
            this.gpVerificacao.Size = new System.Drawing.Size(753, 37);
            this.gpVerificacao.TabIndex = 16;
            this.gpVerificacao.TabStop = false;
            this.gpVerificacao.Text = "Verificação da Eficácia das Ações Implementadas";
            // 
            // dpPrevistaPara
            // 
            this.dpPrevistaPara.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpPrevistaPara.Location = new System.Drawing.Point(75, 14);
            this.dpPrevistaPara.Name = "dpPrevistaPara";
            this.dpPrevistaPara.Size = new System.Drawing.Size(99, 20);
            this.dpPrevistaPara.TabIndex = 21;
            this.dpPrevistaPara.ValueChanged += new System.EventHandler(this.dpPrevistaPara_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Left;
            this.label10.Location = new System.Drawing.Point(3, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(75, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Prevista para: \r\n";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.label9.Location = new System.Drawing.Point(3, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 13);
            this.label9.TabIndex = 0;
            // 
            // gpEficiencia
            // 
            this.gpEficiencia.Controls.Add(this.pbFAQEficiencia);
            this.gpEficiencia.Controls.Add(this.ckeficaz);
            this.gpEficiencia.Controls.Add(this.pnEficacia);
            this.gpEficiencia.Dock = System.Windows.Forms.DockStyle.Top;
            this.gpEficiencia.Location = new System.Drawing.Point(3, 136);
            this.gpEficiencia.Name = "gpEficiencia";
            this.gpEficiencia.Size = new System.Drawing.Size(750, 140);
            this.gpEficiencia.TabIndex = 25;
            this.gpEficiencia.TabStop = false;
            this.gpEficiencia.Text = "Eficiencia da ação";
            // 
            // pbFAQEficiencia
            // 
            this.pbFAQEficiencia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFAQEficiencia.Image = global::RNC.Properties.Resources.faqs;
            this.pbFAQEficiencia.Location = new System.Drawing.Point(728, 25);
            this.pbFAQEficiencia.Name = "pbFAQEficiencia";
            this.pbFAQEficiencia.Size = new System.Drawing.Size(16, 16);
            this.pbFAQEficiencia.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFAQEficiencia.TabIndex = 37;
            this.pbFAQEficiencia.TabStop = false;
            this.pbFAQEficiencia.MouseHover += new System.EventHandler(this.pbFAQEficiencia_MouseHover);
            // 
            // ckeficaz
            // 
            this.ckeficaz.AutoSize = true;
            this.ckeficaz.Location = new System.Drawing.Point(6, 19);
            this.ckeficaz.Name = "ckeficaz";
            this.ckeficaz.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ckeficaz.Size = new System.Drawing.Size(64, 17);
            this.ckeficaz.TabIndex = 31;
            this.ckeficaz.Text = "? Eficaz";
            this.ckeficaz.UseVisualStyleBackColor = true;
            this.ckeficaz.CheckedChanged += new System.EventHandler(this.ckeficaz_CheckedChanged_1);
            // 
            // pnEficacia
            // 
            this.pnEficacia.Controls.Add(this.pbFAQObservaçãoAcao);
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
            this.pnEficacia.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnEficacia.Location = new System.Drawing.Point(3, 47);
            this.pnEficacia.Name = "pnEficacia";
            this.pnEficacia.Size = new System.Drawing.Size(744, 90);
            this.pnEficacia.TabIndex = 36;
            // 
            // pbFAQObservaçãoAcao
            // 
            this.pbFAQObservaçãoAcao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbFAQObservaçãoAcao.Image = global::RNC.Properties.Resources.faqs;
            this.pbFAQObservaçãoAcao.Location = new System.Drawing.Point(725, 74);
            this.pbFAQObservaçãoAcao.Name = "pbFAQObservaçãoAcao";
            this.pbFAQObservaçãoAcao.Size = new System.Drawing.Size(16, 16);
            this.pbFAQObservaçãoAcao.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbFAQObservaçãoAcao.TabIndex = 26;
            this.pbFAQObservaçãoAcao.TabStop = false;
            this.pbFAQObservaçãoAcao.MouseHover += new System.EventHandler(this.pbFAQObservaçãoAcao_MouseHover);
            // 
            // mskNRNC
            // 
            this.mskNRNC.Location = new System.Drawing.Point(326, 43);
            this.mskNRNC.Mask = "999-9999";
            this.mskNRNC.Name = "mskNRNC";
            this.mskNRNC.Size = new System.Drawing.Size(66, 20);
            this.mskNRNC.TabIndex = 48;
            this.mskNRNC.TextChanged += new System.EventHandler(this.mskNRNC_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(305, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nº:";
            // 
            // dpNovoRelatorio
            // 
            this.dpNovoRelatorio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpNovoRelatorio.Location = new System.Drawing.Point(196, 44);
            this.dpNovoRelatorio.Name = "dpNovoRelatorio";
            this.dpNovoRelatorio.Size = new System.Drawing.Size(99, 20);
            this.dpNovoRelatorio.TabIndex = 46;
            // 
            // dpDTVerificada
            // 
            this.dpDTVerificada.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDTVerificada.Location = new System.Drawing.Point(288, 6);
            this.dpDTVerificada.Name = "dpDTVerificada";
            this.dpDTVerificada.Size = new System.Drawing.Size(99, 20);
            this.dpDTVerificada.TabIndex = 45;
            this.dpDTVerificada.ValueChanged += new System.EventHandler(this.dpDTVerificada_ValueChanged);
            // 
            // txtVerificadoPor
            // 
            this.txtVerificadoPor.Location = new System.Drawing.Point(91, 3);
            this.txtVerificadoPor.Name = "txtVerificadoPor";
            this.txtVerificadoPor.Size = new System.Drawing.Size(129, 20);
            this.txtVerificadoPor.TabIndex = 49;
            this.txtVerificadoPor.TextChanged += new System.EventHandler(this.txtVerificadoPor_TextChanged);
            // 
            // cknovorelatorio
            // 
            this.cknovorelatorio.AutoSize = true;
            this.cknovorelatorio.Location = new System.Drawing.Point(10, 47);
            this.cknovorelatorio.Name = "cknovorelatorio";
            this.cknovorelatorio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cknovorelatorio.Size = new System.Drawing.Size(130, 17);
            this.cknovorelatorio.TabIndex = 43;
            this.cknovorelatorio.Text = "?Aberto novo relatório";
            this.cknovorelatorio.UseVisualStyleBackColor = true;
            this.cknovorelatorio.CheckedChanged += new System.EventHandler(this.cknovorelatorio_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(259, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 42;
            this.label16.Text = "Data: ";
            // 
            // txtObservacao
            // 
            this.txtObservacao.AcceptsTab = true;
            this.txtObservacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservacao.Location = new System.Drawing.Point(494, 7);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(221, 65);
            this.txtObservacao.TabIndex = 38;
            this.txtObservacao.Text = "";
            this.txtObservacao.TextChanged += new System.EventHandler(this.txtObservacao_TextChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(11, 9);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(75, 13);
            this.label15.TabIndex = 39;
            this.label15.Text = "Verificado por:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(415, 10);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 13);
            this.label13.TabIndex = 37;
            this.label13.Text = "Observações:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(159, 47);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 13);
            this.label12.TabIndex = 36;
            this.label12.Text = "Data: ";
            this.label12.Visible = false;
            // 
            // pnButtons
            // 
            this.pnButtons.Controls.Add(this.btLimpar);
            this.pnButtons.Controls.Add(this.btGravar);
            this.pnButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnButtons.Location = new System.Drawing.Point(3, 282);
            this.pnButtons.Name = "pnButtons";
            this.pnButtons.Size = new System.Drawing.Size(744, 26);
            this.pnButtons.TabIndex = 48;
            // 
            // btLimpar
            // 
            this.btLimpar.Location = new System.Drawing.Point(119, 3);
            this.btLimpar.Name = "btLimpar";
            this.btLimpar.Size = new System.Drawing.Size(75, 23);
            this.btLimpar.TabIndex = 46;
            this.btLimpar.Text = "Limpar";
            this.btLimpar.UseVisualStyleBackColor = true;
            this.btLimpar.Click += new System.EventHandler(this.btLimpar_Click);
            // 
            // btGravar
            // 
            this.btGravar.Location = new System.Drawing.Point(3, 3);
            this.btGravar.Name = "btGravar";
            this.btGravar.Size = new System.Drawing.Size(75, 23);
            this.btGravar.TabIndex = 45;
            this.btGravar.Text = "Salvar";
            this.btGravar.UseVisualStyleBackColor = true;
            this.btGravar.Click += new System.EventHandler(this.btGravar_Click);
            // 
            // desricaoacaocontrole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "desricaoacaocontrole";
            this.Size = new System.Drawing.Size(756, 312);
            this.Load += new System.EventHandler(this.desricaoacaocontrole_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gpDescricao.ResumeLayout(false);
            this.gpDescricao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQDescriçãoAção)).EndInit();
            this.gpVerificacao.ResumeLayout(false);
            this.gpVerificacao.PerformLayout();
            this.gpEficiencia.ResumeLayout(false);
            this.gpEficiencia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQEficiencia)).EndInit();
            this.pnEficacia.ResumeLayout(false);
            this.pnEficacia.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFAQObservaçãoAcao)).EndInit();
            this.pnButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void pbFAQObservaçãoAcao_MouseHover(object sender, EventArgs e)
        {
            //todo tooltip observação
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQObservaçãoAcao, "Quaisquer observações fnais antes do fechamento.");
        }

        private void pbFAQEficiencia_MouseHover(object sender, EventArgs e)
        {
            //todo tooltip observação
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQEficiencia, "Houve reincidência?");
        }

        private void pbFAQDescriçãoAção_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQDescriçãoAção, "Ação proposta para que a não conformidade não se repita.");
        }

        private void rbCorretiva_CheckedChanged(object sender, EventArgs e)
        {
            string text = ((RadioButton)sender).Text;
            if (text == "Corretiva")
            {
                this.AcaoUsando.tipo = "Corretiva";


            }
            if (text == "Preventiva")
            {
                this.AcaoUsando.tipo = "Preventiva";


            }
            if (text == "Educativa")
            {
                this.AcaoUsando.tipo = "Educativa";


            }
            if (Objprevisaodeacao != null)
            {
                Objprevisaodeacao.lbTipo.Text = text.Trim();
            }

        }
        private void LockAllControllers(Control.ControlCollection control)
        {
            foreach (Control controls in control)
            {
                if (controls is RadioButton || controls is TextBox || controls is CheckBox || controls is RichTextBox || controls is ComboBox || controls is DateTimePicker || controls is Button)
                {
                    if (controls is TextBox)
                    {
                        ((TextBox)controls).ReadOnly = true;
                    }
                    else if (controls is RichTextBox)
                    {
                        ((RichTextBox)controls).ReadOnly = true;
                    }
                    else
                    {
                        controls.Enabled = false;
                    }





                }
                if (controls.HasChildren)
                {
                    LockAllControllers(controls.Controls);

                }

            }


        }
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lParam);
        const int PFM_SPACEBEFORE = 0x00000040;
        const int PFM_SPACEAFTER  = 0x00000080;
        const int PFM_LINESPACING = 0x00000100;
        const int SCF_SELECTION = 1;
        const int EM_SETPARAFORMAT = 1095;

        private void setLineFormat(byte rule, int space, RichTextBox target)
        {
            PARAFORMAT fmt = new PARAFORMAT();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_LINESPACING;
            fmt.dyLineSpacing = space;
            fmt.bLineSpacingRule = rule;
            target.SelectAll();
            SendMessage( new HandleRef( target, target.Handle ),
                EM_SETPARAFORMAT,
                SCF_SELECTION,
                ref fmt
            );
        }
        [StructLayout( LayoutKind.Sequential )]
        public struct PARAFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
            public int[] rgxTabs;
            // PARAFORMAT2 from here onwards
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
        }
    }
}
