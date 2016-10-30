using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EnterSomething
{
    public partial class GUI : Form
    {

        #region General
        public GUI()
        {
            InitializeComponent();
        }
        private void MainDialog_Resize(object sender, System.EventArgs e)
        {
            Control control = (Control)sender;

            this.tbServerOutput.Height = control.Size.Height - 109;
            this.lvServer.Height = control.Size.Height - 129;

            this.tbServerOutput.Width = control.Size.Width - 186;
            this.tbServerInput.Width = control.Size.Width - 232;
        }
        #endregion

        #region Server
        private void btnServerStart_Click(object sender, EventArgs e)
        {
            Server.SetupServer(this);
            tbServerInput.ReadOnly = false;

        }
        private void btnStopServer_Click(object sender, EventArgs e)
        {
            if (Server._serverOnline)
            {
                Server.ShutdownServer();
            }
            else
            {
                tbServerOutput.Text += "Server is already down\r\n";
            }
        }
        private void btnServerSend_Click(object sender, EventArgs e)
        {
            Server.SendMessage();
            this.tbServerInput.Text = "";
        }
        #endregion
    }   // class GUI
}   // namespace EnterSomething