using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNC.ViewModel
{
    public partial class ConsultaRNCView : Form
    {
        relatorio _relatorioRNC;
        public ConsultaRNCView(relatorio relatorio)
        {
            InitializeComponent();

             // StartPosition was set to FormStartPosition.Manual in the properties window.
    Rectangle screen = Screen.PrimaryScreen.WorkingArea;
    int w = this.Width;
    int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
    this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
    this.Size = new Size(w, h);



            _relatorioRNC = relatorio;
            controles.cadastrocontrol cadastro = new controles.cadastrocontrol(_relatorioRNC);
                cadastro.fechar = pnPrincipalView;
            lbRNCID.Text = relatorio.RNCNumber();
            cadastro.RNCID = lbRNCID;
            cadastro.pn_botoes = pnbotoes;
            pnPrincipalView.Controls.Add(cadastro);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            //Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
