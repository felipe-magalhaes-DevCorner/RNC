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
    public partial class PrintDescrição : UserControl
    {
        public PrintDescrição(acaoitem acao)
        {
            InitializeComponent();
            lbDescrição.Text = acao.descricao;
            lbDataPrevista.Text = acao.prevista.ToString("dd/MM/yyyy");
            lbDataRealizada.Text = acao.realizada.ToString("dd/MM/yyyy");
            lbTitulo.Text += acao.tipo;
            lbDataPrevistaVerificação.Text = acao.previstapara.ToString("dd/MM/yyyy");
            if (acao.eficaz)
            {
                labelqualquer.Visible = true;
                label4.Visible = true;
                lbVerificadopor.Visible = true;
                
                label3.Visible = true;
                labelqualquer.Visible = true;
                lbObservação.Text = acao.observacoes;






                if (acao.novorelatorio != "" || !(string.IsNullOrEmpty(acao.novorelatorio.Trim()) ))
                {
                    lbNovoRelatorio.Visible = true;
                    lbObservação.Visible = true;
                    
                    lbNovoRelatorio.Text =
                        $"Aberto novo relatório de numero: {acao.novorelatorio}, na data {acao.datanovorelatorio.ToString("dd/MM/yyyy")}";
                }






            }







        }
    }
}
