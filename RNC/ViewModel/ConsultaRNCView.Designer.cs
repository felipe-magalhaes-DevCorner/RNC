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
            this.panel2 = new System.Windows.Forms.Panel();
            this.pnbotoes = new System.Windows.Forms.Panel();
            this.lbRNCID = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.pnPrincipalView = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(207)))), ((int)(((byte)(103)))), ((int)(((byte)(102)))));
            this.panel2.Controls.Add(this.pnbotoes);
            this.panel2.Controls.Add(this.lbRNCID);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button6);
            this.panel2.Controls.Add(this.button5);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(919, 60);
            this.panel2.TabIndex = 6;
            // 
            // pnbotoes
            // 
            this.pnbotoes.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnbotoes.Location = new System.Drawing.Point(0, 0);
            this.pnbotoes.Name = "pnbotoes";
            this.pnbotoes.Size = new System.Drawing.Size(156, 60);
            this.pnbotoes.TabIndex = 6;
            // 
            // lbRNCID
            // 
            this.lbRNCID.AutoSize = true;
            this.lbRNCID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRNCID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbRNCID.Location = new System.Drawing.Point(664, 25);
            this.lbRNCID.Name = "lbRNCID";
            this.lbRNCID.Size = new System.Drawing.Size(125, 25);
            this.lbRNCID.TabIndex = 5;
            this.lbRNCID.Text = "001 - 2018";
            this.lbRNCID.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbRNCID.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label3.Location = new System.Drawing.Point(154, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(494, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "RELATÓRIO DE NÃO CONFORMIDADE - RNC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(874, 3);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(20, 20);
            this.button6.TabIndex = 3;
            this.button6.Text = "-";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(896, 3);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(20, 20);
            this.button5.TabIndex = 3;
            this.button5.Text = "X";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pnPrincipalView
            // 
            this.pnPrincipalView.BackColor = System.Drawing.Color.White;
            this.pnPrincipalView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPrincipalView.Location = new System.Drawing.Point(2, 62);
            this.pnPrincipalView.Name = "pnPrincipalView";
            this.pnPrincipalView.Size = new System.Drawing.Size(919, 728);
            this.pnPrincipalView.TabIndex = 7;
            // 
            // ConsultaRNCView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(923, 792);
            this.Controls.Add(this.pnPrincipalView);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConsultaRNCView";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta RNC";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Panel pnbotoes;
        public System.Windows.Forms.Label lbRNCID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Panel pnPrincipalView;
    }
}