using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EnterSomething_Client
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

            this.tbClientOutput.Height = control.Size.Height - 109;
            this.lvClient.Height = control.Size.Height - 129;

            this.tbClientOutput.Width = control.Size.Width - 186;
            this.tbClientInput.Width = control.Size.Width - 232;
        }
        #endregion

        #region Client
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (tbClientUsername.Text != "" && tbClientIP.Text != "")
            {
                this.AcceptButton = btnClientSend;
                this.Controls.Clear();
                this.Controls.Add(tlpClientMain);
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
            this.Controls.Clear();
            this.Controls.Add(tlpClientConnect);
        }
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            Client.SendMessage();
        }
        #endregion
    }   // class GUI
}   // namespace EnterSomething_Client