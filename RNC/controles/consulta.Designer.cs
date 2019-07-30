namespace RNC
{
    partial class consulta
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
            this.gbSituacao = new System.Windows.Forms.GroupBox();
            this.txtAno = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btconsulta = new System.Windows.Forms.Button();
            this.dtGridConsulta = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnencerrar = new System.Windows.Forms.Button();
            this.gbSituacao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridConsulta)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSituacao
            // 
            this.gbSituacao.Controls.Add(this.btnencerrar);
            this.gbSituacao.Controls.Add(this.txtAno);
            this.gbSituacao.Controls.Add(this.label1);
            this.gbSituacao.Controls.Add(this.btconsulta);
            this.gbSituacao.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSituacao.Location = new System.Drawing.Point(0, 0);
            this.gbSituacao.Name = "gbSituacao";
            this.gbSituacao.Size = new System.Drawing.Size(685, 52);
            this.gbSituacao.TabIndex = 1;
            this.gbSituacao.TabStop = false;
            this.gbSituacao.Text = "Situação";
            // 
            // txtAno
            // 
            this.txtAno.Location = new System.Drawing.Point(70, 19);
            this.txtAno.Name = "txtAno";
            this.txtAno.Size = new System.Drawing.Size(54, 20);
            this.txtAno.TabIndex = 7;
            this.txtAno.Text = "2018";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "ANO: ";
            // 
            // btconsulta
            // 
            this.btconsulta.Location = new System.Drawing.Point(241, 16);
            this.btconsulta.Name = "btconsulta";
            this.btconsulta.Size = new System.Drawing.Size(75, 23);
            this.btconsulta.TabIndex = 2;
            this.btconsulta.Text = "Pesquisar";
            this.btconsulta.UseVisualStyleBackColor = true;
            this.btconsulta.Click += new System.EventHandler(this.btconsulta_Click);
            // 
            // dtGridConsulta
            // 
            this.dtGridConsulta.AllowUserToAddRows = false;
            this.dtGridConsulta.AllowUserToDeleteRows = false;
            this.dtGridConsulta.AllowUserToResizeColumns = false;
            this.dtGridConsulta.AllowUserToResizeRows = false;
            this.dtGridConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtGridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridConsulta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtGridConsulta.Location = new System.Drawing.Point(0, 0);
            this.dtGridConsulta.Name = "dtGridConsulta";
            this.dtGridConsulta.ReadOnly = true;
            this.dtGridConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridConsulta.ShowEditingIcon = false;
            this.dtGridConsulta.Size = new System.Drawing.Size(685, 410);
            this.dtGridConsulta.TabIndex = 2;
            this.dtGridConsulta.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridConsulta_CellContentDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtGridConsulta);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(685, 410);
            this.panel1.TabIndex = 3;
            // 
            // btnencerrar
            // 
            this.btnencerrar.Location = new System.Drawing.Point(420, 16);
            this.btnencerrar.Name = "btnencerrar";
            this.btnencerrar.Size = new System.Drawing.Size(75, 23);
            this.btnencerrar.TabIndex = 8;
            this.btnencerrar.Text = "Encerrar ";
            this.btnencerrar.UseVisualStyleBackColor = true;
            this.btnencerrar.Click += new System.EventHandler(this.btnencerrar_Click);
            // 
            // consulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbSituacao);
            this.Name = "consulta";
            this.Size = new System.Drawing.Size(685, 462);
            this.gbSituacao.ResumeLayout(false);
            this.gbSituacao.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridConsulta)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbSituacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btconsulta;
        public System.Windows.Forms.TextBox txtAno;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.DataGridView dtGridConsulta;
        private System.Windows.Forms.Button btnencerrar;
    }
}
