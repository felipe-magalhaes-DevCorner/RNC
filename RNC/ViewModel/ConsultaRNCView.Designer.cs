namespace RNC.ViewModel
{
    partial class ConsultaRNCView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnCabecalho = new System.Windows.Forms.Panel();
            this.pnbotoes = new System.Windows.Forms.Panel();
            this.lbRNCID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btMinimize = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.pnPrincipalView = new System.Windows.Forms.Panel();
            this.pnCabecalho.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCabecalho
            // 
            this.pnCabecalho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.pnCabecalho.Controls.Add(this.pnbotoes);
            this.pnCabecalho.Controls.Add(this.lbRNCID);
            this.pnCabecalho.Controls.Add(this.label3);
            this.pnCabecalho.Controls.Add(this.btMinimize);
            this.pnCabecalho.Controls.Add(this.btClose);
            this.pnCabecalho.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCabecalho.Location = new System.Drawing.Point(2, 2);
            this.pnCabecalho.Name = "pnCabecalho";
            this.pnCabecalho.Size = new System.Drawing.Size(997, 60);
            this.pnCabecalho.TabIndex = 6;
            this.pnCabecalho.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Click_MouseDown);
            this.pnCabecalho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Click_MouseMove);
            this.pnCabecalho.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Click_MouseUp);
            // 
            // pnbotoes
            // 
            this.pnbotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnbotoes.Location = new System.Drawing.Point(0, 0);
            this.pnbotoes.Name = "pnbotoes";
            this.pnbotoes.Size = new System.Drawing.Size(180, 60);
            this.pnbotoes.TabIndex = 6;
            // 
            // lbRNCID
            // 
            this.lbRNCID.AutoSize = true;
            this.lbRNCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRNCID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRNCID.Location = new System.Drawing.Point(686, 14);
            this.lbRNCID.Name = "lbRNCID";
            this.lbRNCID.Size = new System.Drawing.Size(125, 25);
            this.lbRNCID.TabIndex = 5;
            this.lbRNCID.Text = "001 - 2018";
            this.lbRNCID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbRNCID.Visible = false;
            this.lbRNCID.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Click_MouseDown);
            this.lbRNCID.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Click_MouseMove);
            this.lbRNCID.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Click_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(186, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(494, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "RELATÓRIO DE NÃO CONFORMIDADE - RNC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Click_MouseDown);
            this.label3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Click_MouseMove);
            this.label3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Click_MouseUp);
            // 
            // btMinimize
            // 
            this.btMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btMinimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btMinimize.Location = new System.Drawing.Point(948, 3);
            this.btMinimize.Name = "btMinimize";
            this.btMinimize.Size = new System.Drawing.Size(20, 20);
            this.btMinimize.TabIndex = 3;
            this.btMinimize.Text = "-";
            this.btMinimize.UseVisualStyleBackColor = true;
            this.btMinimize.Click += new System.EventHandler(this.button6_Click);
            // 
            // btClose
            // 
            this.btClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(974, 3);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(20, 20);
            this.btClose.TabIndex = 3;
            this.btClose.Text = "X";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnPrincipalView
            // 
            this.pnPrincipalView.AutoScroll = true;
            this.pnPrincipalView.AutoSize = true;
            this.pnPrincipalView.BackColor = System.Drawing.Color.White;
            this.pnPrincipalView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipalView.Location = new System.Drawing.Point(2, 62);
            this.pnPrincipalView.Name = "pnPrincipalView";
            this.pnPrincipalView.Size = new System.Drawing.Size(997, 728);
            this.pnPrincipalView.TabIndex = 7;
            // 
            // ConsultaRNCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1001, 792);
            this.Controls.Add(this.pnPrincipalView);
            this.Controls.Add(this.pnCabecalho);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultaRNCView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta RNC";
            this.pnCabecalho.ResumeLayout(false);
            this.pnCabecalho.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnCabecalho;
        public System.Windows.Forms.Panel pnbotoes;
        public System.Windows.Forms.Label lbRNCID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btMinimize;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Panel pnPrincipalView;
    }
}