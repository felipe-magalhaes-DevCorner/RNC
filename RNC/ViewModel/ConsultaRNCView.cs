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
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
