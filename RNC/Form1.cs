using RNC.Data;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RNC
{


    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
            List<string> test = new List<string>();
            test.Add("   ");
            test.Add("   ");
            test.Add("   ");
            test.Add("   ");
            int testeee = test.Count();
            lbVersao.Text = Extensions.softwareVersion;




        }



        private void btcadastro_Click(object sender, EventArgs e)
        {
            StoreRelatorio.ClearRelatorio();
            panelprincipal.Controls.Clear();


            var objcadastrocontrol = new controles.cadastrocontrol();
            objcadastrocontrol.RNCID = lbRNCID;
            objcadastrocontrol.fechar = panelprincipal;
            objcadastrocontrol.pn_botoes = pnbotoes;
            objcadastrocontrol.Dock = DockStyle.Fill;
            panelprincipal.Controls.Add(objcadastrocontrol);


        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void button1_Click_1(object sender, EventArgs e)
        {

            panelprincipal.Controls.Clear();
            var objconsulta = new consulta();

            pnbotoes.Controls.Clear();
            objconsulta.Dock = DockStyle.Fill;
            panelprincipal.Controls.Add(objconsulta);
            panelprincipal.AutoSize = true;




        }

        private void button2_Click(object sender, EventArgs e)
        {

            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = System.IO.Path.Combine(currentDirectory, "About", "index.html");

            System.Diagnostics.Process.Start(filePath);
        }

        #region mouse move

        private bool _mouseDown;
        private Point _lastLocation;
        private void Click_MouseDown(object _sender, MouseEventArgs _e)
        {
            _mouseDown = true;
            _lastLocation = _e.Location;
        }
        private void Click_MouseUp(object _sender, MouseEventArgs _e)
        {
            _mouseDown = false;
        }
        private void Click_MouseMove(object _sender, MouseEventArgs _e)
        {
            if (_mouseDown)
            {
                Location = new Point(
                    Location.X - _lastLocation.X + _e.X, Location.Y - _lastLocation.Y + _e.Y);

                Update();
            }
        }


        #endregion

        private void button3_Click(object sender, EventArgs e)
        {


            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Normal;
            }
            else
            {
                this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            }
        }
    }
}
