using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RNC.comunicacao;
using RNC.Exceptions;

namespace RNC.controles
{
    public partial class cadastrocontrol : UserControl
    {

        public Panel pn_botoes { get; set; }
        public gravar objGravarMain { get; set; }
        private previsaodeacao previsao { get; set; }
        public Panel fechar { get; set; }
        public relatorio relatorioRNC { get; set; }
        public acaoitem acaoSelecionada { get; set; }
        public Label RNCID { get; set; }
        private List<previsaodeacao> listacoes = new List<previsaodeacao>();
        private string numerofinal;
        public Form parentObj { get; set; }

        #region Contrutor

        public cadastrocontrol(relatorio _relatorioRNC = null)
        {
            this.InitializeComponent();
            this.txtemitente.Text = StoreRelatorio.loggedname;
            int a = this.rbaudint.Text.Length;
            int b = this.rbaudext.Text.Length;
            if (_relatorioRNC != null)
            {
                StoreRelatorio.SetRelatorio(_relatorioRNC);
                int aux = StoreRelatorio.GetList().Count<acaoitem>();
                new colecaoBase().SetCount(aux);
                return;
            }

            this.relatorioRNC = _relatorioRNC;
            StoreRelatorio.SetRelatorio(this.relatorioRNC);
        }






        #endregion

        #region Relatorio Handlers

        private void InicializeElements(relatorio _relatorioRNC)
        {
            gravar objGravar = new gravar();
            if (_relatorioRNC == null)
            {
                colecaodeacaoitem colecaoacao = new colecaodeacaoitem();
                buscar bc = new buscar();
                numerofinal = bc.M_peganumerornc();
                relatorioRNC = new relatorio(numerofinal, txtDesRNC.Text, txtemitente.Text, DateTime.Now, cbSetor.Text,
                    null, null, txtInvestigacao.Text, txtDisposicao.Text, "aberta", colecaoacao, null);

                objGravar._cadastro = this;
                objGravarMain = objGravar;
                StoreRelatorio.SetRelatorio(relatorioRNC);
                objGravar.ShouldUpdate = false;
                pn_botoes.Controls.Add(objGravar);
            }
            else
            {
                objGravar.ShouldUpdate = true;
                CarregaRelatorio(_relatorioRNC);
                pn_botoes.Controls.Add(objGravar);

            }


        }

        private void CarregaRelatorio(relatorio _relatorioRNC)
        {
            List<string> fields = _relatorioRNC.GetRelatorioFields();

            for (int i = 0; i < fields.Count; i++)
            {
                switch (i)
                {
                    case 0:
                        this.RNCID.Text = fields[0];
                        break;
                    case 1:
                        this.txtDesRNC.Text = fields[1];
                        break;
                    case 2:
                        this.txtemitente.Text = fields[2];
                        break;
                    case 3:
                        DateTime dateteste = DateTime.ParseExact(fields[3].ToString(), "dd/MM/yyyy",
                            CultureInfo.InvariantCulture);

                        dpDataRNC.Value = dateteste;
                        dpDataRNC.CustomFormat = "dd/MM/yyyy";
                        break;
                    case 4:
                        this.cbSetor.SelectedIndex = this.cbSetor.FindStringExact(fields[4]);
                        break;
                    case 5:
                        {
                            string rbautoria;
                            if (fields[5].Contains("Externa"))
                            {
                                rbautoria = fields[5].Substring(0, 27);
                                string comentario = fields[5].Substring(27);
                                this.txtexterna.Text = comentario;
                            }
                            else if (fields[5].Contains("Interna"))
                            {
                                rbautoria = fields[5].Substring(0, 34);
                                string comentario = fields[5].Substring(34);
                                this.txtauditoria.Text = comentario;
                            }
                            else
                            {
                                rbautoria = fields[5];
                            }

                            this.gbOrigen.Controls.OfType<RadioButton>()
                                .FirstOrDefault((RadioButton n) => n.Text.Contains(rbautoria)).Checked = true;
                            break;
                        }
                    case 6:
                        {
                            var buttons = gbtnc.Controls.OfType<RadioButton>()
                                .FirstOrDefault(n => n.Text.Contains(fields[6]));
                            buttons.Checked = true;

                            break;
                        }
                    case 7:
                        this.txtInvestigacao.Text = fields[7];
                        break;
                    case 8:
                        this.txtDisposicao.Text = fields[8];
                        break;

                    case 9:
                        {
                            var buttons = gbRisco.Controls.OfType<RadioButton>()
                                .FirstOrDefault(n => n.Text.Contains(fields[10]));
                            buttons.Checked = true;
                            break;
                        }

                }
            }

            this.pnacaoitem.Controls.Clear();
            using (List<acaoitem>.Enumerator enumerator = _relatorioRNC.GetList().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    previsaodeacao previsao = new previsaodeacao(enumerator.Current);
                    previsao.setOrigenPanel(this.flowpanelAcao);
                    previsao.M_setpainel(this.pnacaoitem);
                    this.flowpanelAcao.Controls.Add(previsao);
                }
            }


        }

        #endregion

        #region LOAD

        private void cadastrocontrol_Load(object sender, EventArgs e)
        {

            InicializeElements(StoreRelatorio.GetRelatorio());
            StoreRelatorio.CadastroUsing = this;

            RNCID.Visible = true;
            if (numerofinal != null)
            {
                RNCID.Text = numerofinal;
            }
            else
            {
                numerofinal = RNCID.Text;
            }





        }

        #endregion

        #region Checkbox Handlers

        private void rbaudint_CheckedChanged_1(object sender, EventArgs e)
        {

            if (rbaudint.Checked == true)
            {
                txtauditoria.Visible = true;
            }
            else
            {
                txtauditoria.Visible = false;
            }
        }

        private void rbaudext_CheckedChanged(object sender, EventArgs e)
        {
            if (rbaudext.Checked == true)
            {
                txtexterna.Visible = true;
            }
            else
            {
                txtexterna.Visible = false;
            }
        }

        #endregion

        #region Click Handlers

        private void button2_Click(object sender, EventArgs e)
        {

            fechar.Controls.Clear();
        }

        private void btadd_Click(object sender, EventArgs e)
        {
            StoreRelatorio.GetList();
            int arg_16_0 = this.flowpanelAcao.Controls.Count;
            previsaodeacao objPrevisao = new previsaodeacao(new acaoitem(0));
            objPrevisao.setOrigenPanel(this.flowpanelAcao);
            this.pnacaoitem.Controls.Clear();
            objPrevisao.M_setpainel(this.pnacaoitem);
            this.flowpanelAcao.Controls.Add(objPrevisao);

        }

        #endregion

        #region Methodos Gravar

        public cadastrocontrol GetCadastro()
        {
            return this;
        }

        public string GetInformation()
        {
            //para ser alterado para item relatorio
            string info = "";
            var buttons = gbOrigen.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked);
            var origemnc = buttons.Text;
            if ((buttons.TabIndex == 2) || (buttons.TabIndex == 3))
            {
                origemnc = buttons.Text + txtauditoria.Text + txtexterna.Text;
            }

            var tnc = gbtnc.Controls.OfType<RadioButton>()
                .FirstOrDefault(n => n.Checked);
            var butttnc = tnc.Text;
            info = "'" + numerofinal + "','" + txtDesRNC.Text + "' , '" + txtemitente.Text + "' , '" +
                   dpDataRNC.Value.ToString("MM/dd/yyyy") + "' , '" +
                   origemnc + "' , '" + butttnc + "' , '" + txtInvestigacao.Text + "' , '" + txtDisposicao.Text +
                   "', 'aberta')";
            return info;
        }

        public relatorio ToRelatorioConvert(relatorio _relatorio = null)
        {
            try
            {
                var buttons = gbOrigen.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);
                if (buttons == null || buttons.Text == "")
                {
                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar todas as opcoes de Radio Button!");
                }

                var origemnc = buttons.Text;
                if ((buttons.TabIndex == 2) || (buttons.TabIndex == 3))
                {
                    origemnc = buttons.Text + txtauditoria.Text + txtexterna.Text;
                    if (origemnc == buttons.Text)
                    {
                        throw new Exceptions.BlankFieldEx(
                            "Para selecionar auditoria, o campo em frente deve ser preenchido!");
                    }
                }
                var gbRisco = this.gbRisco.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);
                if (gbRisco == null || gbRisco.Text =="")
                {
                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar todas as opcoes de Radio Button!");
                }
                var risco = gbRisco.Text;

                
                var tnc = gbtnc.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);
                if (tnc == null || tnc.Text =="")
                {
                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar todas as opcoes de Radio Button!");
                }
                var butttnc = tnc.Text;
                colecaodeacaoitem colecao = new colecaodeacaoitem();
                colecao = StoreRelatorio.GetColecao();
                DateTime date = dpDataRNC.Value;
                relatorioRNC = new relatorio(numerofinal, txtDesRNC.Text, txtemitente.Text, date, cbSetor.Text,
                    origemnc, butttnc, txtInvestigacao.Text, txtDisposicao.Text, "aberta", colecao, risco);
                return relatorioRNC;

            }
            catch (NoButtonSelected e)
            {
                MessageBox.Show(e.ToString());
                return null;
                //throw;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
                //throw;
            }



        }



        #endregion

        #region Exception Checks

        public void checkBlanks()
        {
            try
            {
                Exceptions.Thower.BlackFieldThrower(txtDesRNC.Text);
                Exceptions.Thower.BlackFieldThrower(txtemitente.Text);
                Exceptions.Thower.BlackFieldThrower(cbSetor.Text);

            }
            catch (Exceptions.BlankFieldEx ex)
            {

                MessageBox.Show(ex.Message);

                throw;
            }

        }

        #endregion

    }
}

