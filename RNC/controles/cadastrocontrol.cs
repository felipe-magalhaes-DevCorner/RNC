using RNC.comunicacao;
using RNC.Exceptions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// ReSharper disable ComplexConditionExpression

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
            label7.Text = "MainPanel Size = " + MainPanel.Height;
            label5.Text = "PnAcao Size = "  + pnacaoitem.Height;
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
            LineSpacing(1, 2);


        }

        private void LineSpacing(byte rule,int space)
        {
            setLineFormat(1, 2, txtDesRNC);
            setLineFormat(1, 2, txtDisposicao);
            setLineFormat(1, 2, txtInvestigacao);
            
            //setLineFormat(1, 2, txt);


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
                    null, null, txtInvestigacao.Text, txtDisposicao.Text, "Aberta", colecaoacao, null);

                objGravar._cadastro = this;
                objGravar.btPrint.Visible = false;
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
            bool RNCFechada = false;
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
                            if (fields[9].ToString().Trim() == "Fechada")
                            {
                                RNCFechada = true;
                                LockAllControllers(this.Controls);
                            }

                            break;
                        }
                    case 10:
                        {
                            var buttons = gbRisco.Controls.OfType<RadioButton>()
                                .FirstOrDefault(n => n.Text.Contains(fields[10]));
                            buttons.Checked = true;
                            break;
                        }


                }
            }

            //todo handle locking if closed
            this.pnacaoitem.Controls.Clear();
            using (List<acaoitem>.Enumerator enumerator = _relatorioRNC.GetList().GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    previsaodeacao previsao = new previsaodeacao(enumerator.Current, RNCFechada);
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
        [DllImport("user32", CharSet = CharSet.Auto)]
        private static extern IntPtr SendMessage(HandleRef hWnd, int msg, int wParam, ref PARAFORMAT lParam);
        const int PFM_SPACEBEFORE = 0x00000040;
        const int PFM_SPACEAFTER  = 0x00000080;
        const int PFM_LINESPACING = 0x00000100;
        const int SCF_SELECTION = 1;
        const int EM_SETPARAFORMAT = 1095;

        private void setLineFormat(byte rule, int space, RichTextBox target)
        {
            PARAFORMAT fmt = new PARAFORMAT();
            fmt.cbSize = Marshal.SizeOf(fmt);
            fmt.dwMask = PFM_LINESPACING;
            fmt.dyLineSpacing = space;
            fmt.bLineSpacingRule = rule;
            target.SelectAll();
            SendMessage( new HandleRef( target, target.Handle ),
                EM_SETPARAFORMAT,
                SCF_SELECTION,
                ref fmt
            );
        }
        [StructLayout( LayoutKind.Sequential )]
        public struct PARAFORMAT
        {
            public int cbSize;
            public uint dwMask;
            public short wNumbering;
            public short wReserved;
            public int dxStartIndent;
            public int dxRightIndent;
            public int dxOffset;
            public short wAlignment;
            public short cTabCount;
            [MarshalAs( UnmanagedType.ByValArray, SizeConst = 32 )]
            public int[] rgxTabs;
            // PARAFORMAT2 from here onwards
            public int dySpaceBefore;
            public int dySpaceAfter;
            public int dyLineSpacing;
            public short sStyle;
            public byte bLineSpacingRule;
            public byte bOutlineLevel;
            public short wShadingWeight;
            public short wShadingStyle;
            public short wNumberingStart;
            public short wNumberingStyle;
            public short wNumberingTab;
            public short wBorderSpace;
            public short wBorderWidth;
            public short wBorders;
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
                txtauditoria.Text = "";
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
                txtexterna.Text = "";
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
                   "', 'Aberta')";
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
                if (buttons.TabIndex == 2 || buttons.TabIndex == 3 || buttons.TabIndex == 7)
                {
                    origemnc = buttons.Text + txtauditoria.Text + txtexterna.Text + txtOutros.Text;
                    if (origemnc == buttons.Text)
                    {


                        throw new Exceptions.BlankFieldEx(
                            "Para selecionar auditoria, o campo em frente deve ser preenchido!");

                    }
                }
                var gbRisco = this.gbRisco.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);
                if (gbRisco == null || gbRisco.Text == "")
                {

                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar todas as opcoes de Radio Button!");
                    ;
                }
                var risco = gbRisco.Text;


                var tnc = gbtnc.Controls.OfType<RadioButton>()
                    .FirstOrDefault(n => n.Checked);
                if (tnc == null || tnc.Text == "")
                {

                    throw new Exceptions.NoButtonSelected(
                        "É nescessario selecionar todas as opcoes de Radio Button!");
                }
                var butttnc = tnc.Text;
                colecaodeacaoitem colecao = new colecaodeacaoitem();
                colecao = StoreRelatorio.GetColecao();
                DateTime date = dpDataRNC.Value;
                relatorioRNC = new relatorio(numerofinal, txtDesRNC.Text, txtemitente.Text, date, cbSetor.Text,
                    origemnc, butttnc, txtInvestigacao.Text, txtDisposicao.Text, "Aberta", colecao, risco);
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

        private void rbOutros_CheckedChanged(object sender, EventArgs e)
        {

            if (rbOutros.Checked == true)
            {
                txtOutros.Visible = true;
            }
            else
            {
                txtOutros.Visible = false;
                txtOutros.Text = "";
            }
        }

        bool mouseClicked = false;

        private void Resize_MouseDown(object sender, MouseEventArgs e)
        {
            mouseClicked = true;
            resixermoreFluid = ((Panel)sender).Parent.Height;

            if (sender is Panel)
            {
                resixermoreFluid = ((Panel)sender).Parent.Height;
            }

            if (sender is GroupBox)
            {
                resixermoreFluid = ((Panel)sender).Parent.Height;
            }



        }

        private int resixermoreFluid;
        private void Resize_MouseUp(object sender, MouseEventArgs e)
        {

            mouseClicked = false;
            if (sender is Panel)
            {
                ((Panel)sender).Parent.Height = resixermoreFluid;
            }

            if (sender is GroupBox)
            {
                ((GroupBox)sender).Parent.Height = resixermoreFluid;
            }

        }

        private void Resize_MouseMove(object sender, MouseEventArgs e)
        {

            if (mouseClicked)
            {


                resixermoreFluid = ((Panel)sender).Top + e.Y;
                //PanelReiszer.Parent.Height = pictureBox1.Top + e.Y;
                //PanelReiszer.Parent.Width = pictureBox1.Top + e.Y;
                //this.panel1.Height = pictureBox1.Top + e.Y;
                //this.panel1.Width = pictureBox1.Left + e.X;

            }
        }

        private void pbFAQOrigem_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQOrigem, "Fonte da não conformidade");
        }

        private void pbFAQTratamento_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQTratamento, "Açoes Corretiva: Visa eliminar a causa de uma nao conformidade." +
                                                Environment.NewLine +
                                                "Ação educativa: Visa esclarecer a causa de uma não conformidade que não nescessita de ação corretiva ou melhoria." +
                                                Environment.NewLine +
                                                "Melhoria: Visa evitar/melhorar possiveis não conformidades.");



        }

        private void pbFAQRisco_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(this.pbFAQRisco, "De acordo com o item 'Gestão de risco' do manual da qualidade");
        }

        private void LockAllControllers(Control.ControlCollection control)
        {
            foreach (Control controls in control)
            {
                if (controls is RadioButton || controls is TextBox || controls is RichTextBox || controls is ComboBox || controls is DateTimePicker || controls is CheckBox)
                {
                    if (controls is TextBox)
                    {
                        ((TextBox)controls).ReadOnly = true;
                    }
                    else if (controls is RichTextBox)
                    {
                        ((RichTextBox)controls).ReadOnly = true;
                    }
                    else
                    {
                        controls.Enabled = false;
                    }



                }
                if (controls.HasChildren)
                {
                    LockAllControllers(controls.Controls);

                }

            }


        }

        private void rbOutros_CheckedChanged_1(object sender, EventArgs e)
        {
            if (rbOutros.Checked)
                txtOutros.Visible = true;
            else
                txtOutros.Visible = false;
            
        }

        private void pnacaoitem_Resize(object sender, EventArgs e)
        {
            label5.Text = "PNAcao size = " + pnacaoitem.Height;
            label7.Text = "MainPanel size = " + MainPanel.Height;
        }
    }
}

