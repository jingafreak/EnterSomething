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

            tbClientOutput.Height = control.Size.Height - 109;
            lvClient.Height = control.Size.Height - 129;

            tbClientOutput.Width = control.Size.Width - 186;
            tbClientInput.Width = control.Size.Width - 232;
        }
        #endregion

        #region Client
        private void btnClientConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhitespace(tbClientUsername.Text) && !string.IsNullOrWhitespace(tbClientIP.Text))
            {
                AcceptButton = btnClientSend;
                Controls.Clear();
                Controls.Add(tlpClientMain);
                MinimumSize = new Size(692, 364);
                Size = new Size(692, 364);
                MaximizeBox = true;
                MinimizeBox = true;
                FormBorderStyle = FormBorderStyle.Sizable;
                CenterToScreen();
                
                Client.Connect(this);

                tbClientIP.Text = "";
                tbClientUsername.Text = "";
                tbClientInput.ReadOnly = false;
            }
            else
            {
                MessageBox.Show("Please enter IP and Username", "Wrong input",
                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation,
                           MessageBoxDefaultButton.Button1);
                tbClientUsername.Text = "";
                tbClientIP.Text = "";
            }
        }
        private void btnClientDisconnect_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            Controls.Clear();
            Controls.Add(tlpClientConnect);
        }
        private void btnClientSend_Click(object sender, EventArgs e)
        {
            Client.SendMessage();
            tbClientInput.Text = "";
        }
        #endregion
    }   // class GUI
}   // namespace EnterSomething_Client
