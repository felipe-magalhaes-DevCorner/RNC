using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RNC.ViewModel
{
    public partial class PrintView : UserControl
    {
        public PrintView(relatorio relatorio)
        {
            InitializeComponent();



            lbDescrição.MaximumSize = new Size(pnFullPanel.Width, 0);

            var information = relatorio.GetRelatorioFields();
            lbRNCID.Text = relatorio.RNCNumber();
            lbDescrição.Text = information[1];
            lbEmitente.Text = information[2];
            lbData.Text = information[3];
            lbSetor.Text = information[4];
            lbOrigem.Text = information[5];
            lbTratamento.Text = information[6];
            lbInvestigaçãoCausa.Text = information[7];
            lbDisposição.Text = information[8];
            lbStatus.Text += @"        "  + information[9];
            lbRisco.Text = information[10];

            ResizeLabels(this.Controls);
            var ações = relatorio.GetList();
            if (ações.Count > 0)
            {
                foreach (var acao in ações)
                {
                    var printdescrição = new PrintDescrição(acao);
                    pnAções.Controls.Add(printdescrição);
                    ResizeLabels(printdescrição.Controls);


                }
                
            }





        }

        public void ResizeLabels (Control.ControlCollection controlscollection)
        {
            foreach (Control control in controlscollection)
            {
                if (control is Label)
                {

                    control.MaximumSize = new Size(pnFullPanel.Width, 0);
                }
                else
                {
                    if (control.HasChildren)
                    {
                        ResizeLabels(control.Controls);
                    }
                    
                }
                
            }

        }

       
    }
}
