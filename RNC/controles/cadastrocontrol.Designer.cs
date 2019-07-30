namespace RNC.controles
{
    partial class cadastrocontrol
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDesRNC = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbSetor = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dpDataRNC = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtemitente = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbOrigen = new System.Windows.Forms.GroupBox();
            this.txtexterna = new System.Windows.Forms.TextBox();
            this.rbverificacaocontrole = new System.Windows.Forms.RadioButton();
            this.rbreclamacao = new System.Windows.Forms.RadioButton();
            this.rbinspecao = new System.Windows.Forms.RadioButton();
            this.txtauditoria = new System.Windows.Forms.TextBox();
            this.rbaudext = new System.Windows.Forms.RadioButton();
            this.rbaudint = new System.Windows.Forms.RadioButton();
            this.rboutros = new System.Windows.Forms.RadioButton();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtInvestigacao = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.gbDisposicao = new System.Windows.Forms.GroupBox();
            this.txtDisposicao = new System.Windows.Forms.RichTextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gbtnc = new System.Windows.Forms.GroupBox();
            this.rbacaoeducativa = new System.Windows.Forms.RadioButton();
            this.rbacaopreventiva = new System.Windows.Forms.RadioButton();
            this.rbacaocorretiva = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.gbRisco = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.flowpanelAcao = new System.Windows.Forms.FlowLayoutPanel();
            this.btadd = new System.Windows.Forms.Button();
            this.pnacaoitem = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbOrigen.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.gbDisposicao.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gbtnc.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gbRisco.SuspendLayout();
            this.flowpanelAcao.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Descrição da Não Conformidade (Real ou Potencial)";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDesRNC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(956, 68);
            this.panel1.TabIndex = 1;
            // 
            // txtDesRNC
            // 
            this.txtDesRNC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDesRNC.Location = new System.Drawing.Point(0, 13);
            this.txtDesRNC.Name = "txtDesRNC";
            this.txtDesRNC.Size = new System.Drawing.Size(956, 55);
            this.txtDesRNC.TabIndex = 1;
            this.txtDesRNC.Text = "";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cbSetor);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.dpDataRNC);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtemitente);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 68);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(956, 38);
            this.panel2.TabIndex = 2;
            // 
            // cbSetor
            // 
            this.cbSetor.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbSetor.FormattingEnabled = true;
            this.cbSetor.Items.AddRange(new object[] {
            "Informatica",
            "Area Tecnica"});
            this.cbSetor.Location = new System.Drawing.Point(579, 0);
            this.cbSetor.Name = "cbSetor";
            this.cbSetor.Size = new System.Drawing.Size(121, 21);
            this.cbSetor.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(547, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Setor";
            // 
            // dpDataRNC
            // 
            this.dpDataRNC.Dock = System.Windows.Forms.DockStyle.Left;
            this.dpDataRNC.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDataRNC.Location = new System.Drawing.Point(463, 0);
            this.dpDataRNC.Name = "dpDataRNC";
            this.dpDataRNC.Size = new System.Drawing.Size(84, 20);
            this.dpDataRNC.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(427, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Data: ";
            // 
            // txtemitente
            // 
            this.txtemitente.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtemitente.Location = new System.Drawing.Point(58, 0);
            this.txtemitente.Name = "txtemitente";
            this.txtemitente.Size = new System.Drawing.Size(369, 20);
            this.txtemitente.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(4, 3, 0, 0);
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Emitente: ";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbOrigen);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 106);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(956, 78);
            this.panel3.TabIndex = 3;
            // 
            // gbOrigen
            // 
            this.gbOrigen.Controls.Add(this.txtexterna);
            this.gbOrigen.Controls.Add(this.rbverificacaocontrole);
            this.gbOrigen.Controls.Add(this.rbreclamacao);
            this.gbOrigen.Controls.Add(this.rbinspecao);
            this.gbOrigen.Controls.Add(this.txtauditoria);
            this.gbOrigen.Controls.Add(this.rbaudext);
            this.gbOrigen.Controls.Add(this.rbaudint);
            this.gbOrigen.Controls.Add(this.rboutros);
            this.gbOrigen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOrigen.Location = new System.Drawing.Point(0, 0);
            this.gbOrigen.Name = "gbOrigen";
            this.gbOrigen.Size = new System.Drawing.Size(956, 78);
            this.gbOrigen.TabIndex = 0;
            this.gbOrigen.TabStop = false;
            this.gbOrigen.Text = "Origem: ";
            // 
            // txtexterna
            // 
            this.txtexterna.Location = new System.Drawing.Point(254, 54);
            this.txtexterna.Name = "txtexterna";
            this.txtexterna.Size = new System.Drawing.Size(79, 20);
            this.txtexterna.TabIndex = 8;
            this.txtexterna.Visible = false;
            // 
            // rbverificacaocontrole
            // 
            this.rbverificacaocontrole.AutoSize = true;
            this.rbverificacaocontrole.Location = new System.Drawing.Point(441, 6);
            this.rbverificacaocontrole.Name = "rbverificacaocontrole";
            this.rbverificacaocontrole.Size = new System.Drawing.Size(199, 17);
            this.rbverificacaocontrole.TabIndex = 4;
            this.rbverificacaocontrole.TabStop = true;
            this.rbverificacaocontrole.Text = "Verificação de Controle em Processo\r\n";
            this.rbverificacaocontrole.UseVisualStyleBackColor = true;
            // 
            // rbreclamacao
            // 
            this.rbreclamacao.AutoSize = true;
            this.rbreclamacao.Location = new System.Drawing.Point(69, 9);
            this.rbreclamacao.Name = "rbreclamacao";
            this.rbreclamacao.Size = new System.Drawing.Size(135, 17);
            this.rbreclamacao.TabIndex = 1;
            this.rbreclamacao.TabStop = true;
            this.rbreclamacao.Text = "Reclamação de Cliente";
            this.rbreclamacao.UseVisualStyleBackColor = true;
            // 
            // rbinspecao
            // 
            this.rbinspecao.AutoSize = true;
            this.rbinspecao.Location = new System.Drawing.Point(441, 32);
            this.rbinspecao.Name = "rbinspecao";
            this.rbinspecao.Size = new System.Drawing.Size(206, 17);
            this.rbinspecao.TabIndex = 5;
            this.rbinspecao.TabStop = true;
            this.rbinspecao.Text = "Inspeção de Recebimento da Amostra";
            this.rbinspecao.UseVisualStyleBackColor = true;
            // 
            // txtauditoria
            // 
            this.txtauditoria.Location = new System.Drawing.Point(254, 31);
            this.txtauditoria.Name = "txtauditoria";
            this.txtauditoria.Size = new System.Drawing.Size(79, 20);
            this.txtauditoria.TabIndex = 7;
            this.txtauditoria.Visible = false;
            // 
            // rbaudext
            // 
            this.rbaudext.AutoSize = true;
            this.rbaudext.Location = new System.Drawing.Point(69, 55);
            this.rbaudext.Name = "rbaudext";
            this.rbaudext.Size = new System.Drawing.Size(157, 17);
            this.rbaudext.TabIndex = 3;
            this.rbaudext.TabStop = true;
            this.rbaudext.Text = "Auditoria Externa/Inspeção:";
            this.rbaudext.UseVisualStyleBackColor = true;
            this.rbaudext.CheckedChanged += new System.EventHandler(this.rbaudext_CheckedChanged);
            // 
            // rbaudint
            // 
            this.rbaudint.AutoSize = true;
            this.rbaudint.Location = new System.Drawing.Point(69, 32);
            this.rbaudint.Name = "rbaudint";
            this.rbaudint.Size = new System.Drawing.Size(179, 17);
            this.rbaudint.TabIndex = 2;
            this.rbaudint.TabStop = true;
            this.rbaudint.Text = "Auditoria Interna/Auto Inspeção:\r\n";
            this.rbaudint.UseVisualStyleBackColor = true;
            this.rbaudint.CheckedChanged += new System.EventHandler(this.rbaudint_CheckedChanged_1);
            // 
            // rboutros
            // 
            this.rboutros.AutoSize = true;
            this.rboutros.Location = new System.Drawing.Point(441, 54);
            this.rboutros.Name = "rboutros";
            this.rboutros.Size = new System.Drawing.Size(214, 17);
            this.rboutros.TabIndex = 6;
            this.rboutros.TabStop = true;
            this.rboutros.Text = "Outros: CONTROLE EXTERNO - PELM";
            this.rboutros.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.txtInvestigacao);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 230);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(956, 76);
            this.panel5.TabIndex = 6;
            // 
            // txtInvestigacao
            // 
            this.txtInvestigacao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInvestigacao.Location = new System.Drawing.Point(0, 13);
            this.txtInvestigacao.Name = "txtInvestigacao";
            this.txtInvestigacao.Size = new System.Drawing.Size(956, 63);
            this.txtInvestigacao.TabIndex = 2;
            this.txtInvestigacao.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Investigação da Causa: ";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.gbDisposicao);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 306);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(956, 71);
            this.panel6.TabIndex = 7;
            // 
            // gbDisposicao
            // 
            this.gbDisposicao.Controls.Add(this.txtDisposicao);
            this.gbDisposicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDisposicao.Location = new System.Drawing.Point(0, 0);
            this.gbDisposicao.Name = "gbDisposicao";
            this.gbDisposicao.Size = new System.Drawing.Size(956, 71);
            this.gbDisposicao.TabIndex = 0;
            this.gbDisposicao.TabStop = false;
            this.gbDisposicao.Text = "Disposição:";
            // 
            // txtDisposicao
            // 
            this.txtDisposicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDisposicao.Location = new System.Drawing.Point(3, 16);
            this.txtDisposicao.Name = "txtDisposicao";
            this.txtDisposicao.Size = new System.Drawing.Size(950, 52);
            this.txtDisposicao.TabIndex = 0;
            this.txtDisposicao.Text = "";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gbtnc);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 184);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(956, 46);
            this.panel4.TabIndex = 4;
            // 
            // gbtnc
            // 
            this.gbtnc.Controls.Add(this.rbacaoeducativa);
            this.gbtnc.Controls.Add(this.rbacaopreventiva);
            this.gbtnc.Controls.Add(this.rbacaocorretiva);
            this.gbtnc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbtnc.Location = new System.Drawing.Point(0, 0);
            this.gbtnc.Name = "gbtnc";
            this.gbtnc.Size = new System.Drawing.Size(956, 46);
            this.gbtnc.TabIndex = 12;
            this.gbtnc.TabStop = false;
            this.gbtnc.Text = "Tratamento da não conformidade:";
            // 
            // rbacaoeducativa
            // 
            this.rbacaoeducativa.AutoSize = true;
            this.rbacaoeducativa.Location = new System.Drawing.Point(247, 19);
            this.rbacaoeducativa.Name = "rbacaoeducativa";
            this.rbacaoeducativa.Size = new System.Drawing.Size(101, 17);
            this.rbacaoeducativa.TabIndex = 9;
            this.rbacaoeducativa.TabStop = true;
            this.rbacaoeducativa.Text = "Ação Educativa";
            this.rbacaoeducativa.UseVisualStyleBackColor = true;
            // 
            // rbacaopreventiva
            // 
            this.rbacaopreventiva.AutoSize = true;
            this.rbacaopreventiva.Location = new System.Drawing.Point(404, 19);
            this.rbacaopreventiva.Name = "rbacaopreventiva";
            this.rbacaopreventiva.Size = new System.Drawing.Size(104, 17);
            this.rbacaopreventiva.TabIndex = 8;
            this.rbacaopreventiva.TabStop = true;
            this.rbacaopreventiva.Text = "Ação Preventiva";
            this.rbacaopreventiva.UseVisualStyleBackColor = true;
            // 
            // rbacaocorretiva
            // 
            this.rbacaocorretiva.AutoSize = true;
            this.rbacaocorretiva.Location = new System.Drawing.Point(69, 19);
            this.rbacaocorretiva.Name = "rbacaocorretiva";
            this.rbacaocorretiva.Size = new System.Drawing.Size(95, 17);
            this.rbacaocorretiva.TabIndex = 7;
            this.rbacaocorretiva.TabStop = true;
            this.rbacaocorretiva.Text = "Ação Corretiva";
            this.rbacaocorretiva.UseVisualStyleBackColor = true;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.gbRisco);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel7.Location = new System.Drawing.Point(0, 377);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(956, 46);
            this.panel7.TabIndex = 13;
            // 
            // gbRisco
            // 
            this.gbRisco.Controls.Add(this.radioButton1);
            this.gbRisco.Controls.Add(this.radioButton2);
            this.gbRisco.Controls.Add(this.radioButton3);
            this.gbRisco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbRisco.Location = new System.Drawing.Point(0, 0);
            this.gbRisco.Name = "gbRisco";
            this.gbRisco.Size = new System.Drawing.Size(956, 46);
            this.gbRisco.TabIndex = 14;
            this.gbRisco.TabStop = false;
            this.gbRisco.Text = "Análise de Risco:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(247, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 17);
            this.radioButton1.TabIndex = 9;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Moderada";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(404, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 17);
            this.radioButton2.TabIndex = 8;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Grave";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(69, 19);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(49, 17);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Leve";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // flowpanelAcao
            // 
            this.flowpanelAcao.Controls.Add(this.btadd);
            this.flowpanelAcao.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowpanelAcao.Location = new System.Drawing.Point(0, 423);
            this.flowpanelAcao.Name = "flowpanelAcao";
            this.flowpanelAcao.Size = new System.Drawing.Size(200, 319);
            this.flowpanelAcao.TabIndex = 14;
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(3, 3);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(18, 21);
            this.btadd.TabIndex = 0;
            this.btadd.Text = "+";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // pnacaoitem
            // 
            this.pnacaoitem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnacaoitem.Location = new System.Drawing.Point(200, 423);
            this.pnacaoitem.Name = "pnacaoitem";
            this.pnacaoitem.Size = new System.Drawing.Size(756, 319);
            this.pnacaoitem.TabIndex = 15;
            // 
            // cadastrocontrol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnacaoitem);
            this.Controls.Add(this.flowpanelAcao);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "cadastrocontrol";
            this.Size = new System.Drawing.Size(956, 742);
            this.Load += new System.EventHandler(this.cadastrocontrol_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbOrigen.ResumeLayout(false);
            this.gbOrigen.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.gbDisposicao.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gbtnc.ResumeLayout(false);
            this.gbtnc.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.gbRisco.ResumeLayout(false);
            this.gbRisco.PerformLayout();
            this.flowpanelAcao.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbverificacaocontrole;
        private System.Windows.Forms.RadioButton rbreclamacao;
        private System.Windows.Forms.RadioButton rbinspecao;
        private System.Windows.Forms.RadioButton rbaudext;
        private System.Windows.Forms.RadioButton rbaudint;
        private System.Windows.Forms.RadioButton rboutros;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        public System.Windows.Forms.TextBox txtexterna;
        public System.Windows.Forms.TextBox txtauditoria;
        public System.Windows.Forms.TextBox txtemitente;
        public System.Windows.Forms.RichTextBox txtDesRNC;
        private System.Windows.Forms.GroupBox gbOrigen;
        private System.Windows.Forms.ComboBox cbSetor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dpDataRNC;
        public System.Windows.Forms.RichTextBox txtInvestigacao;
        private System.Windows.Forms.GroupBox gbDisposicao;
        public System.Windows.Forms.RichTextBox txtDisposicao;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.GroupBox gbtnc;
        private System.Windows.Forms.RadioButton rbacaoeducativa;
        private System.Windows.Forms.RadioButton rbacaopreventiva;
        private System.Windows.Forms.RadioButton rbacaocorretiva;
        private System.Windows.Forms.Panel panel7;
        public System.Windows.Forms.GroupBox gbRisco;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.FlowLayoutPanel flowpanelAcao;
        private System.Windows.Forms.Button btadd;
        public System.Windows.Forms.Panel pnacaoitem;
    }
}
