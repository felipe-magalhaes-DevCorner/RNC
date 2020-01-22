using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNC
{


    public partial class consulta : UserControl
    {
        ConnectionClass db = new ConnectionClass();
        buscar buscar = new buscar();

        public DataTable _dt;

        public consulta()
        {
            InitializeComponent();
            txtAno.Text = DateTime.Now.Year.ToString();
        }

        private void btconsulta_Click(object sender, EventArgs e)
        {

            buscar.objConsulta = this;
            buscar.Pesquisaano();
            


        }

        private void dtGridConsulta_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string idRNC = dtGridConsulta.SelectedCells[0].Value.ToString();
            relatorio _relatorio =  buscar.PegaRelatorioSql(idRNC);
            StoreRelatorio.SetRelatorio(_relatorio);
            ViewModel.ConsultaRNCView objView = new ViewModel.ConsultaRNCView(_relatorio);
            objView.ShowDialog();


        }

        private void btnencerrar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Essa é uma ação sem volta, tem certeza que deseja encerrar a RNC?", "Atenção", MessageBoxButtons.YesNo);
            if(dialogResult == DialogResult.Yes)
            {
                if (buscar.Encerrarnc())
                {
                
                    buscar.objConsulta = this;
                    buscar.Pesquisaano();

                }
            }
        }



        private void pbFAQConsulta_MouseHover(object sender, EventArgs e)
        {
            //todo tooltip consulta
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQConsulta, "Digite o ano desejado para consultar" + Environment.NewLine + 
                                              "Encerrar: conclui a ação.");


        }

        private void pbFAQConsulta_Click(object sender, EventArgs e)
        {

        }
    }
}
