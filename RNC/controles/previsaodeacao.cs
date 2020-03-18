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
        private bool RNCfechada = false;

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

        public previsaodeacao(acaoitem _acao, bool locked = false)
        {
            this.InitializeComponent();
            RNCfechada = locked;
            this.lbData.Text = DateTime.Now.ToString("dd/MM/yyyy");
            this.AcaoUsed = _acao;
            if (this.AcaoUsed.descricao != null)
            {
                if (this.AcaoUsed.tipo.Trim() == "Corretiva")
                {
                    this.lbTipo.Text = "Corretiva";
                }
                else if (this.AcaoUsed.tipo.Trim() == "Preventiva")
                {
                    this.lbTipo.Text = "Preventiva";
                }
                else if (this.AcaoUsed.tipo.Trim() == "Educativa")
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
            desricaoacaocontrole descricao = new desricaoacaocontrole(this.AcaoUsed, RNCfechada);
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
            this.lbDescri = new System.Windows.Forms.Label();
            this.lbTipo = new System.Windows.Forms.Label();
            this.lbData = new System.Windows.Forms.Label();
            this.pncoracao = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lbDescri
            // 
            this.lbDescri.AutoSize = true;
            this.lbDescri.Location = new System.Drawing.Point(38, 6);
            this.lbDescri.Name = "lbDescri";
            this.lbDescri.Size = new System.Drawing.Size(79, 13);
            this.lbDescri.TabIndex = 0;
            this.lbDescri.Text = "Ações exemplo";
            this.lbDescri.Click += new System.EventHandler(this.previsaodeacao_Click);
            // 
            // lbTipo
            // 
            this.lbTipo.AutoSize = true;
            this.lbTipo.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTipo.Location = new System.Drawing.Point(58, 23);
            this.lbTipo.Name = "lbTipo";
            this.lbTipo.Size = new System.Drawing.Size(74, 13);
            this.lbTipo.TabIndex = 1;
            this.lbTipo.Text = "Selecione tipo";
            this.lbTipo.Click += new System.EventHandler(this.previsaodeacao_Click);
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbData.ForeColor = System.Drawing.Color.DarkBlue;
            this.lbData.Location = new System.Drawing.Point(121, 42);
            this.lbData.Name = "lbData";
            this.lbData.Size = new System.Drawing.Size(75, 13);
            this.lbData.TabIndex = 3;
            this.lbData.Text = "19/04/2018";
            this.lbData.Click += new System.EventHandler(this.previsaodeacao_Click);
            // 
            // pncoracao
            // 
            this.pncoracao.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.pncoracao.Dock = System.Windows.Forms.DockStyle.Left;
            this.pncoracao.Location = new System.Drawing.Point(0, 0);
            this.pncoracao.Name = "pncoracao";
            this.pncoracao.Size = new System.Drawing.Size(32, 58);
            this.pncoracao.TabIndex = 4;
            this.pncoracao.Click += new System.EventHandler(this.previsaodeacao_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.Beige;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(32, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(166, 3);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // previsaodeacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pncoracao);
            this.Controls.Add(this.lbData);
            this.Controls.Add(this.lbTipo);
            this.Controls.Add(this.lbDescri);
            this.Name = "previsaodeacao";
            this.Size = new System.Drawing.Size(198, 58);
            this.Load += new System.EventHandler(this.previsaodeacao_Load);
            this.Click += new System.EventHandler(this.previsaodeacao_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
