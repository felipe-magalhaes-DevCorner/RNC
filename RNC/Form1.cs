using RNC.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNC.Data;

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
            



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
    }
}
