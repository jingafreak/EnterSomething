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
            var control = (Control)sender;

            tbServerOutput.Height = control.Size.Height - 109;
            lvServer.Height = control.Size.Height - 129;

            tbServerOutput.Width = control.Size.Width - 186;
            tbServerInput.Width = control.Size.Width - 232;
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
                tbServerOutput.Text += "Server is already down" + Environment.NewLine;
            }
        }
        private void btnServerSend_Click(object sender, EventArgs e)
        {
            Server.SendMessage();
            tbServerInput.Text = string.Empty;
        }
        #endregion
    }   // class GUI
}   // namespace EnterSomething
