using RNC.Properties;
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace RNC
{
	public class login : Form
	{
		private connectionclassgmn db = new connectionclassgmn();

		public static string loginName;

		public static string firstName;

		public static string lastName;

		private static bool control;

		private IContainer components;

		private TextBox txtsenha;

		private Label label1;

		private Label label2;

		private ComboBox comboBox1;

		private Label label3;

		private Label label4;

		private Button button2;
        private PictureBox pictureBox1;
        private Button button1;

		public Form getform
		{
			get;
			set;
		}

		public login(bool _control = false)
		{
			this.InitializeComponent();
			login.control = _control;
			this.txtsenha.Clear();
		}

		public login()
		{
			this.InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			login.loginName = this.comboBox1.Text;
			this.db.SqlConnection();
			string query = "select USUARIOS.FIRSTNAME,USUARIOS.LASTNAME,USUARIOS.USUARIO,USUARIOS.SIGLA AS SENHA from USUARIOS where USUARIOS.BLOQUEADO = 'F' AND USUARIOS.USUARIO =  '" + this.comboBox1.Text + "'";
			this.db.SqlQuery(query);
			Clipboard.SetText(query);
			SqlDataReader _dr = this.db.SingleCellReader();
			if (!_dr.HasRows)
			{
				MessageBox.Show("Usuário Inexistente.");
			}
			while (_dr.Read())
			{
				if (this.LoginSQl(_dr["USUARIO"].ToString(), _dr["SENHA"].ToString()))
				{
					login.loginName = _dr["USUARIO"].ToString();
					login.firstName = _dr["FIRSTNAME"].ToString();
					login.lastName = _dr["LASTNAME"].ToString();
					login.control = true;
					StoreRelatorio.loggedname = login.firstName + " " + login.lastName;
					Form arg_102_0 = new Form1();
					base.Hide();
					arg_102_0.ShowDialog();
				}
				else
				{
					login.control = false;
				}
			}
		}

		private bool LoginSQl(string nome, string password)
		{
			if (!(this.comboBox1.Text != ""))
			{
				MessageBox.Show("Favor informar um login.");
				return false;
			}
			if (!(this.txtsenha.Text != ""))
			{
				MessageBox.Show("Favor informar uma senha.");
				return false;
			}
			if (nome == this.comboBox1.Text && password == this.txtsenha.Text)
			{
				return true;
			}
			MessageBox.Show("Login ou senha incorretos.");
			return false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void login_Load(object sender, EventArgs e)
		{
			this.db.SqlConnection();
			string query = "select USUARIOS.USUARIO from USUARIOS where USUARIOS.BLOQUEADO = 'F'";
			this.db.SqlQuery(query);
			Clipboard.SetText(query);
			SqlDataReader reader = this.db.SingleCellReader();
			DataTable dt = new DataTable();
			dt.Columns.Add("USUARIO", typeof(string));
			dt.Load(reader);
			this.comboBox1.ValueMember = "USUARIO";
			this.comboBox1.DisplayMember = "USUARIO";
			this.comboBox1.DataSource = dt;
			this.db.closeConnection();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			base.Close();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.txtsenha = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtsenha
            // 
            this.txtsenha.Location = new System.Drawing.Point(108, 149);
            this.txtsenha.MaxLength = 100;
            this.txtsenha.Name = "txtsenha";
            this.txtsenha.PasswordChar = '*';
            this.txtsenha.Size = new System.Drawing.Size(199, 20);
            this.txtsenha.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.button1.Location = new System.Drawing.Point(54, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(28, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(28, 144);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Senha: ";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(108, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(164, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nefrolab";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(148, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 42);
            this.label3.TabIndex = 20;
            this.label3.Text = "GMN";
            // 
            // button2
            // 
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.button2.Location = new System.Drawing.Point(208, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Sair";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(66, 10);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 84);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // login
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(38)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(350, 228);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtsenha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
