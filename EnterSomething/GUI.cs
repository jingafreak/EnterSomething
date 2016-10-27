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

            this.tbClientOutput.Height = control.Size.Height - 109;
            this.lvClient.Height = control.Size.Height - 129;

            this.tbClientOutput.Width = control.Size.Width - 186;
            this.tbClientInput.Width = control.Size.Width - 232;
        }
        private void tc_Selecting(object sender, TabControlCancelEventArgs e)
        {
            TabPage current = (sender as TabControl).SelectedTab;
            if (current == tabServer)
            {
                this.AcceptButton = btnServerSend;
                this.MinimumSize = new Size(692, 364);
                this.Size = new Size(692, 364);
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.CenterToScreen();
                this.tbClientUsername.Text = "";
                this.tbClientIP.Text = "";

            }
            else if (current == tabClient)
            {
                if (this.tabClient.Controls[0] == tlpClientConnect)
                {
                    this.AcceptButton = btnClientConnect;
                    this.MinimumSize = new Size(200, 150);
                    this.Size = new Size(200, 150);
                    this.MaximizeBox = false;
                    this.MinimizeBox = false;
                    this.FormBorderStyle = FormBorderStyle.FixedSingle;
                    this.CenterToScreen();
                }
                else if (this.tabClient.Controls[0] == tlpClientMain)
                {
                    this.AcceptButton = btnClientSend;
                    this.MinimumSize = new Size(692, 364);
                    this.Size = new Size(692, 364);
                    this.MaximizeBox = true;
                    this.MinimizeBox = true;
                    this.FormBorderStyle = FormBorderStyle.Sizable;
                    this.CenterToScreen();
                    this.tbClientUsername.Text = "";
                    this.tbClientIP.Text = "";
                }
            }
            this.Refresh();
            MainDialog_Resize(this, new EventArgs());
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
        }
        #endregion

        #region Client
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (tbClientUsername.Text != "" && tbClientIP.Text != "")
            {
                this.tabClient.Controls.Clear();
                this.tabClient.Controls.Add(tlpClientMain);
                this.MinimumSize = new Size(692, 364);
                this.Size = new Size(692, 364);
                this.MaximizeBox = true;
                this.MinimizeBox = true;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.CenterToScreen();

                Thread tClientLoop = new Thread(delegate ()
                {
                    Client.Connect(this);
                });

                this.tbClientIP.Text = "";
                this.tbClientUsername.Text = "";
                this.tbClientInput.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Please enter IP and Username", "Wrong input",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button1);
                this.tbClientUsername.Text = "";
                this.tbClientIP.Text = "";
            }
        }
        private void btnClientDisconnect_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            this.tabClient.Controls.Clear();
            this.tabClient.Controls.Add(tlpClientConnect);
        }
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            Client.SendMessage();
        }
        #endregion
    }   // class GUI
}   // namespace EnterSomething