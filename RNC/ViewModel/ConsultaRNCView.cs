using System;
using System.Drawing;
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

        public relatorio GetRelatorio()
        {
            return _relatorioRNC;
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

    }
}
