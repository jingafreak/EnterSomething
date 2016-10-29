using System.Windows.Forms;

namespace EnterSomething_Client
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }   // Dispose()

        #region Windows Form Designer generated code
        
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GUI));
            this.tlpClientMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpClientChats = new System.Windows.Forms.TableLayoutPanel();
            this.lblClientChats = new System.Windows.Forms.Label();
            this.lvClient = new System.Windows.Forms.ListView();
            this.btnClientDisconnect = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tbClientOutput = new System.Windows.Forms.TextBox();
            this.tlpClientInput = new System.Windows.Forms.TableLayoutPanel();
            this.tbClientInput = new System.Windows.Forms.TextBox();
            this.btnClientSend = new System.Windows.Forms.Button();
            this.tlpClientConnect = new System.Windows.Forms.TableLayoutPanel();
            this.tbClientIP = new System.Windows.Forms.TextBox();
            this.lblClientUsername = new System.Windows.Forms.Label();
            this.lblClientIP = new System.Windows.Forms.Label();
            this.tbClientUsername = new System.Windows.Forms.TextBox();
            this.btnClientConnect = new System.Windows.Forms.Button();
            this.tlpClientMain.SuspendLayout();
            this.tlpClientChats.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tlpClientInput.SuspendLayout();
            this.tlpClientConnect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpClientMain
            // 
            this.tlpClientMain.ColumnCount = 2;
            this.tlpClientMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpClientMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientMain.Controls.Add(this.tlpClientChats, 0, 0);
            this.tlpClientMain.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tlpClientMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientMain.Location = new System.Drawing.Point(0, 0);
            this.tlpClientMain.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpClientMain.Name = "tlpClientMain";
            this.tlpClientMain.RowCount = 1;
            this.tlpClientMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tlpClientMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tlpClientMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 293F));
            this.tlpClientMain.Size = new System.Drawing.Size(676, 325);
            this.tlpClientMain.TabIndex = 1;
            // 
            // tlpClientChats
            // 
            this.tlpClientChats.ColumnCount = 1;
            this.tlpClientChats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientChats.Controls.Add(this.lblClientChats, 0, 0);
            this.tlpClientChats.Controls.Add(this.lvClient, 0, 1);
            this.tlpClientChats.Controls.Add(this.btnClientDisconnect, 0, 2);
            this.tlpClientChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientChats.Location = new System.Drawing.Point(0, 3);
            this.tlpClientChats.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpClientChats.Name = "tlpClientChats";
            this.tlpClientChats.RowCount = 3;
            this.tlpClientChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpClientChats.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpClientChats.Size = new System.Drawing.Size(150, 319);
            this.tlpClientChats.TabIndex = 1;
            // 
            // lblClientChats
            // 
            this.lblClientChats.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblClientChats.AutoSize = true;
            this.lblClientChats.Location = new System.Drawing.Point(58, 3);
            this.lblClientChats.Name = "lblClientChats";
            this.lblClientChats.Size = new System.Drawing.Size(34, 13);
            this.lblClientChats.TabIndex = 0;
            this.lblClientChats.Text = "Chats";
            // 
            // lvClient
            // 
            this.lvClient.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = null;
            this.lvClient.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvClient.Location = new System.Drawing.Point(3, 23);
            this.lvClient.Name = "lvClient";
            this.lvClient.Size = new System.Drawing.Size(144, 235);
            this.lvClient.TabIndex = 1;
            this.lvClient.UseCompatibleStateImageBehavior = false;
            // 
            // btnClientDisconnect
            // 
            this.btnClientDisconnect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClientDisconnect.Location = new System.Drawing.Point(3, 264);
            this.btnClientDisconnect.Name = "btnClientDisconnect";
            this.btnClientDisconnect.Size = new System.Drawing.Size(144, 20);
            this.btnClientDisconnect.TabIndex = 2;
            this.btnClientDisconnect.Text = "Disconnect";
            this.btnClientDisconnect.UseVisualStyleBackColor = true;
            this.btnClientDisconnect.Click += new System.EventHandler(this.btnClientDisconnect_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.tbClientOutput, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tlpClientInput, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(150, 3);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(526, 319);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // tbClientOutput
            // 
            this.tbClientOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbClientOutput.HideSelection = false;
            this.tbClientOutput.Location = new System.Drawing.Point(3, 3);
            this.tbClientOutput.MaxLength = 0;
            this.tbClientOutput.Multiline = true;
            this.tbClientOutput.Name = "tbClientOutput";
            this.tbClientOutput.ReadOnly = true;
            this.tbClientOutput.Size = new System.Drawing.Size(520, 255);
            this.tbClientOutput.TabIndex = 2;
            // 
            // tlpClientInput
            // 
            this.tlpClientInput.ColumnCount = 2;
            this.tlpClientInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientInput.Controls.Add(this.tbClientInput, 0, 0);
            this.tlpClientInput.Controls.Add(this.btnClientSend, 1, 0);
            this.tlpClientInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientInput.Location = new System.Drawing.Point(0, 261);
            this.tlpClientInput.Margin = new System.Windows.Forms.Padding(0);
            this.tlpClientInput.Name = "tlpClientInput";
            this.tlpClientInput.RowCount = 1;
            this.tlpClientInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClientInput.Size = new System.Drawing.Size(526, 58);
            this.tlpClientInput.TabIndex = 3;
            // 
            // tbClientInput
            // 
            this.tbClientInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbClientInput.Location = new System.Drawing.Point(3, 3);
            this.tbClientInput.Name = "tbClientInput";
            this.tbClientInput.ReadOnly = true;
            this.tbClientInput.Size = new System.Drawing.Size(460, 20);
            this.tbClientInput.TabIndex = 0;
            // 
            // btnClientSend
            // 
            this.btnClientSend.Location = new System.Drawing.Point(469, 3);
            this.btnClientSend.Name = "btnClientSend";
            this.btnClientSend.Size = new System.Drawing.Size(41, 20);
            this.btnClientSend.TabIndex = 1;
            this.btnClientSend.Text = "Send";
            this.btnClientSend.UseVisualStyleBackColor = true;
            this.btnClientSend.Click += new System.EventHandler(this.btnClientSend_Click);
            // 
            // tlpClientConnect
            // 
            this.tlpClientConnect.ColumnCount = 2;
            this.tlpClientConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientConnect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpClientConnect.Controls.Add(this.tbClientIP, 1, 1);
            this.tlpClientConnect.Controls.Add(this.lblClientUsername, 0, 0);
            this.tlpClientConnect.Controls.Add(this.lblClientIP, 0, 1);
            this.tlpClientConnect.Controls.Add(this.tbClientUsername, 1, 0);
            this.tlpClientConnect.Controls.Add(this.btnClientConnect, 1, 2);
            this.tlpClientConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClientConnect.Location = new System.Drawing.Point(0, 0);
            this.tlpClientConnect.Name = "tlpClientConnect";
            this.tlpClientConnect.RowCount = 3;
            this.tlpClientConnect.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientConnect.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientConnect.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpClientConnect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpClientConnect.Size = new System.Drawing.Size(184, 82);
            this.tlpClientConnect.TabIndex = 6;
            // 
            // tbClientIP
            // 
            this.tbClientIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbClientIP.Location = new System.Drawing.Point(67, 29);
            this.tbClientIP.Name = "tbClientIP";
            this.tbClientIP.Size = new System.Drawing.Size(94, 20);
            this.tbClientIP.TabIndex = 10;
            // 
            // lblClientUsername
            // 
            this.lblClientUsername.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblClientUsername.AutoSize = true;
            this.lblClientUsername.Location = new System.Drawing.Point(6, 6);
            this.lblClientUsername.Name = "lblClientUsername";
            this.lblClientUsername.Size = new System.Drawing.Size(55, 13);
            this.lblClientUsername.TabIndex = 6;
            this.lblClientUsername.Text = "Username";
            // 
            // lblClientIP
            // 
            this.lblClientIP.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblClientIP.AutoSize = true;
            this.lblClientIP.Location = new System.Drawing.Point(3, 32);
            this.lblClientIP.Name = "lblClientIP";
            this.lblClientIP.Size = new System.Drawing.Size(58, 13);
            this.lblClientIP.TabIndex = 7;
            this.lblClientIP.Text = "IP-Address";
            // 
            // tbClientUsername
            // 
            this.tbClientUsername.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbClientUsername.Location = new System.Drawing.Point(67, 3);
            this.tbClientUsername.Name = "tbClientUsername";
            this.tbClientUsername.Size = new System.Drawing.Size(94, 20);
            this.tbClientUsername.TabIndex = 9;
            // 
            // btnClientConnect
            // 
            this.btnClientConnect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnClientConnect.Location = new System.Drawing.Point(67, 55);
            this.btnClientConnect.Name = "btnClientConnect";
            this.btnClientConnect.Size = new System.Drawing.Size(75, 23);
            this.btnClientConnect.TabIndex = 12;
            this.btnClientConnect.Text = "Connect";
            this.btnClientConnect.UseVisualStyleBackColor = true;
            this.btnClientConnect.Click += new System.EventHandler(this.btnClientConnect_Click);
            // 
            // GUI
            // 
            this.AcceptButton = this.btnClientConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 82);
            this.Controls.Add(this.tlpClientConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 121);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterSomething";
            this.Resize += new System.EventHandler(this.MainDialog_Resize);
            this.tlpClientMain.ResumeLayout(false);
            this.tlpClientChats.ResumeLayout(false);
            this.tlpClientChats.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tlpClientInput.ResumeLayout(false);
            this.tlpClientInput.PerformLayout();
            this.tlpClientConnect.ResumeLayout(false);
            this.tlpClientConnect.PerformLayout();
            this.ResumeLayout(false);

        }   // InitializeComponent()

        #endregion
        public TableLayoutPanel tlpClientMain;
        public TableLayoutPanel tlpClientChats;
        public Label lblClientChats;
        public ListView lvClient;
        public Button btnClientDisconnect;
        public TableLayoutPanel tableLayoutPanel4;
        public TextBox tbClientOutput;
        public TableLayoutPanel tlpClientInput;
        public TextBox tbClientInput;
        public Button btnClientSend;
        public TableLayoutPanel tlpClientConnect;
        public TextBox tbClientIP;
        public Label lblClientUsername;
        public Label lblClientIP;
        public TextBox tbClientUsername;
        public Button btnClientConnect;
    }   // class MainDialog()
}   // namespace EnterSomething_Client