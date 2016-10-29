using System.Windows.Forms;

namespace EnterSomething
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
            this.tlpServerMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpServerChats = new System.Windows.Forms.TableLayoutPanel();
            this.lblServerChats = new System.Windows.Forms.Label();
            this.lvServer = new System.Windows.Forms.ListView();
            this.tlpServerButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnStopServer = new System.Windows.Forms.Button();
            this.btnServerStart = new System.Windows.Forms.Button();
            this.tlpServerIO = new System.Windows.Forms.TableLayoutPanel();
            this.tbServerOutput = new System.Windows.Forms.TextBox();
            this.tlpServerInput = new System.Windows.Forms.TableLayoutPanel();
            this.tbServerInput = new System.Windows.Forms.TextBox();
            this.btnServerSend = new System.Windows.Forms.Button();
            this.tlpServerMain.SuspendLayout();
            this.tlpServerChats.SuspendLayout();
            this.tlpServerButtons.SuspendLayout();
            this.tlpServerIO.SuspendLayout();
            this.tlpServerInput.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpServerMain
            // 
            this.tlpServerMain.ColumnCount = 2;
            this.tlpServerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpServerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpServerMain.Controls.Add(this.tlpServerChats, 0, 0);
            this.tlpServerMain.Controls.Add(this.tlpServerIO, 1, 0);
            this.tlpServerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerMain.Location = new System.Drawing.Point(0, 0);
            this.tlpServerMain.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpServerMain.Name = "tlpServerMain";
            this.tlpServerMain.RowCount = 1;
            this.tlpServerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerMain.Size = new System.Drawing.Size(676, 294);
            this.tlpServerMain.TabIndex = 0;
            // 
            // tlpServerChats
            // 
            this.tlpServerChats.ColumnCount = 1;
            this.tlpServerChats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerChats.Controls.Add(this.lblServerChats, 0, 0);
            this.tlpServerChats.Controls.Add(this.lvServer, 0, 1);
            this.tlpServerChats.Controls.Add(this.tlpServerButtons, 0, 2);
            this.tlpServerChats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerChats.Location = new System.Drawing.Point(0, 3);
            this.tlpServerChats.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpServerChats.Name = "tlpServerChats";
            this.tlpServerChats.RowCount = 3;
            this.tlpServerChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpServerChats.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpServerChats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpServerChats.Size = new System.Drawing.Size(150, 288);
            this.tlpServerChats.TabIndex = 1;
            // 
            // lblServerChats
            // 
            this.lblServerChats.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblServerChats.AutoSize = true;
            this.lblServerChats.Location = new System.Drawing.Point(58, 3);
            this.lblServerChats.Name = "lblServerChats";
            this.lblServerChats.Size = new System.Drawing.Size(34, 13);
            this.lblServerChats.TabIndex = 0;
            this.lblServerChats.Text = "Chats";
            // 
            // lvServer
            // 
            this.lvServer.Dock = System.Windows.Forms.DockStyle.Fill;
            listViewGroup1.Header = "ListViewGroup";
            listViewGroup1.Name = null;
            this.lvServer.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
            this.lvServer.Location = new System.Drawing.Point(3, 23);
            this.lvServer.Name = "lvServer";
            this.lvServer.Size = new System.Drawing.Size(144, 235);
            this.lvServer.TabIndex = 1;
            this.lvServer.UseCompatibleStateImageBehavior = false;
            // 
            // tlpServerButtons
            // 
            this.tlpServerButtons.ColumnCount = 2;
            this.tlpServerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpServerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpServerButtons.Controls.Add(this.btnStopServer, 0, 0);
            this.tlpServerButtons.Controls.Add(this.btnServerStart, 1, 0);
            this.tlpServerButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerButtons.Location = new System.Drawing.Point(0, 261);
            this.tlpServerButtons.Margin = new System.Windows.Forms.Padding(0);
            this.tlpServerButtons.Name = "tlpServerButtons";
            this.tlpServerButtons.RowCount = 1;
            this.tlpServerButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerButtons.Size = new System.Drawing.Size(150, 27);
            this.tlpServerButtons.TabIndex = 2;
            // 
            // btnStopServer
            // 
            this.btnStopServer.Location = new System.Drawing.Point(3, 3);
            this.btnStopServer.Name = "btnStopServer";
            this.btnStopServer.Size = new System.Drawing.Size(69, 20);
            this.btnStopServer.TabIndex = 0;
            this.btnStopServer.Text = "Stop";
            this.btnStopServer.UseVisualStyleBackColor = true;
            this.btnStopServer.Click += new System.EventHandler(this.btnStopServer_Click);
            // 
            // btnServerStart
            // 
            this.btnServerStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnServerStart.Location = new System.Drawing.Point(78, 3);
            this.btnServerStart.Name = "btnServerStart";
            this.btnServerStart.Size = new System.Drawing.Size(69, 20);
            this.btnServerStart.TabIndex = 1;
            this.btnServerStart.Text = "Start";
            this.btnServerStart.UseVisualStyleBackColor = true;
            this.btnServerStart.Click += new System.EventHandler(this.btnServerStart_Click);
            // 
            // tlpServerIO
            // 
            this.tlpServerIO.ColumnCount = 1;
            this.tlpServerIO.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerIO.Controls.Add(this.tbServerOutput, 0, 0);
            this.tlpServerIO.Controls.Add(this.tlpServerInput, 0, 1);
            this.tlpServerIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerIO.Location = new System.Drawing.Point(150, 3);
            this.tlpServerIO.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.tlpServerIO.Name = "tlpServerIO";
            this.tlpServerIO.RowCount = 2;
            this.tlpServerIO.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpServerIO.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpServerIO.Size = new System.Drawing.Size(526, 288);
            this.tlpServerIO.TabIndex = 2;
            // 
            // tbServerOutput
            // 
            this.tbServerOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServerOutput.HideSelection = false;
            this.tbServerOutput.Location = new System.Drawing.Point(3, 3);
            this.tbServerOutput.MaxLength = 0;
            this.tbServerOutput.Multiline = true;
            this.tbServerOutput.Name = "tbServerOutput";
            this.tbServerOutput.ReadOnly = true;
            this.tbServerOutput.Size = new System.Drawing.Size(520, 255);
            this.tbServerOutput.TabIndex = 2;
            // 
            // tlpServerInput
            // 
            this.tlpServerInput.ColumnCount = 2;
            this.tlpServerInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpServerInput.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpServerInput.Controls.Add(this.tbServerInput, 0, 0);
            this.tlpServerInput.Controls.Add(this.btnServerSend, 1, 0);
            this.tlpServerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerInput.Location = new System.Drawing.Point(0, 261);
            this.tlpServerInput.Margin = new System.Windows.Forms.Padding(0);
            this.tlpServerInput.Name = "tlpServerInput";
            this.tlpServerInput.RowCount = 1;
            this.tlpServerInput.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerInput.Size = new System.Drawing.Size(526, 27);
            this.tlpServerInput.TabIndex = 3;
            // 
            // tbServerInput
            // 
            this.tbServerInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbServerInput.Location = new System.Drawing.Point(3, 3);
            this.tbServerInput.Name = "tbServerInput";
            this.tbServerInput.ReadOnly = true;
            this.tbServerInput.Size = new System.Drawing.Size(473, 20);
            this.tbServerInput.TabIndex = 0;
            // 
            // btnServerSend
            // 
            this.btnServerSend.Location = new System.Drawing.Point(482, 3);
            this.btnServerSend.Name = "btnServerSend";
            this.btnServerSend.Size = new System.Drawing.Size(41, 20);
            this.btnServerSend.TabIndex = 1;
            this.btnServerSend.Text = "Send";
            this.btnServerSend.UseVisualStyleBackColor = true;
            this.btnServerSend.Click += new System.EventHandler(this.btnServerSend_Click);
            // 
            // GUI
            // 
            this.AcceptButton = this.btnServerSend;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 294);
            this.Controls.Add(this.tlpServerMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(692, 333);
            this.Name = "GUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterSomething - Server";
            this.Resize += new System.EventHandler(this.MainDialog_Resize);
            this.tlpServerMain.ResumeLayout(false);
            this.tlpServerChats.ResumeLayout(false);
            this.tlpServerChats.PerformLayout();
            this.tlpServerButtons.ResumeLayout(false);
            this.tlpServerIO.ResumeLayout(false);
            this.tlpServerIO.PerformLayout();
            this.tlpServerInput.ResumeLayout(false);
            this.tlpServerInput.PerformLayout();
            this.ResumeLayout(false);

        }   // InitializeComponent()

        #endregion
        public TableLayoutPanel tlpServerMain;
        public TableLayoutPanel tlpServerChats;
        public Label lblServerChats;
        public ListView lvServer;
        public TableLayoutPanel tlpServerButtons;
        public Button btnStopServer;
        public Button btnServerStart;
        public TableLayoutPanel tlpServerIO;
        public TextBox tbServerOutput;
        public TableLayoutPanel tlpServerInput;
        public TextBox tbServerInput;
        public Button btnServerSend;
    }   // class MainDialog()
}   // namespace EnterSomething