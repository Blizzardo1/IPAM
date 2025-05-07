namespace IPAM;

partial class IpamWindow
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        CreateNetworkBtn = new Button();
        IpAddressTxt = new TextBox();
        label1 = new Label();
        label2 = new Label();
        IpamList = new FlowLayoutPanel();
        NetworkCbx = new ComboBox();
        RemoveNetworkBtn = new Button();
        label3 = new Label();
        SubnetCbx = new ComboBox();
        NetworkNameTxt = new TextBox();
        label4 = new Label();
        menuStrip1 = new MenuStrip();
        fileToolStripMenuItem = new ToolStripMenuItem();
        loadToolStripMenuItem = new ToolStripMenuItem();
        saveToolStripMenuItem = new ToolStripMenuItem();
        toolStripMenuItem1 = new ToolStripSeparator();
        exitToolStripMenuItem = new ToolStripMenuItem();
        importFromToolStripMenuItem = new ToolStripMenuItem();
        commaSeparatedValuescsvToolStripMenuItem = new ToolStripMenuItem();
        menuStrip1.SuspendLayout();
        SuspendLayout();
        // 
        // CreateNetworkBtn
        // 
        CreateNetworkBtn.Location = new Point(664, 27);
        CreateNetworkBtn.Name = "CreateNetworkBtn";
        CreateNetworkBtn.Size = new Size(103, 23);
        CreateNetworkBtn.TabIndex = 4;
        CreateNetworkBtn.Text = "Create Network";
        CreateNetworkBtn.UseVisualStyleBackColor = true;
        CreateNetworkBtn.Click += CreateNetworkBtn_Click;
        // 
        // IpAddressTxt
        // 
        IpAddressTxt.AcceptsReturn = true;
        IpAddressTxt.Location = new Point(50, 27);
        IpAddressTxt.MaxLength = 15;
        IpAddressTxt.Name = "IpAddressTxt";
        IpAddressTxt.PlaceholderText = "192.168.0.0";
        IpAddressTxt.Size = new Size(148, 23);
        IpAddressTxt.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 31);
        label1.Name = "label1";
        label1.Size = new Size(32, 16);
        label1.TabIndex = 0;
        label1.Text = "CIDR";
        // 
        // label2
        // 
        label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        label2.AutoSize = true;
        label2.Location = new Point(787, 31);
        label2.Name = "label2";
        label2.Size = new Size(52, 16);
        label2.TabIndex = 0;
        label2.Text = "Network";
        // 
        // IpamList
        // 
        IpamList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        IpamList.AutoScroll = true;
        IpamList.BorderStyle = BorderStyle.Fixed3D;
        IpamList.FlowDirection = FlowDirection.TopDown;
        IpamList.Location = new Point(12, 57);
        IpamList.Name = "IpamList";
        IpamList.Size = new Size(1122, 621);
        IpamList.TabIndex = 3;
        // 
        // NetworkCbx
        // 
        NetworkCbx.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        NetworkCbx.FormattingEnabled = true;
        NetworkCbx.Location = new Point(845, 28);
        NetworkCbx.Name = "NetworkCbx";
        NetworkCbx.Size = new Size(177, 24);
        NetworkCbx.TabIndex = 5;
        NetworkCbx.SelectedIndexChanged += NetworkCbx_SelectedIndexChanged;
        // 
        // RemoveNetworkBtn
        // 
        RemoveNetworkBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        RemoveNetworkBtn.Location = new Point(1029, 27);
        RemoveNetworkBtn.Name = "RemoveNetworkBtn";
        RemoveNetworkBtn.Size = new Size(105, 23);
        RemoveNetworkBtn.TabIndex = 6;
        RemoveNetworkBtn.Text = "Remove Network";
        RemoveNetworkBtn.UseVisualStyleBackColor = true;
        RemoveNetworkBtn.Click += RemoveNetworkBtn_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(212, 31);
        label3.Name = "label3";
        label3.Size = new Size(44, 16);
        label3.TabIndex = 0;
        label3.Text = "Subnet";
        // 
        // SubnetCbx
        // 
        SubnetCbx.FormattingEnabled = true;
        SubnetCbx.Location = new Point(262, 28);
        SubnetCbx.Name = "SubnetCbx";
        SubnetCbx.Size = new Size(173, 24);
        SubnetCbx.TabIndex = 2;
        // 
        // NetworkNameTxt
        // 
        NetworkNameTxt.Location = new Point(536, 28);
        NetworkNameTxt.Name = "NetworkNameTxt";
        NetworkNameTxt.PlaceholderText = "Local";
        NetworkNameTxt.Size = new Size(122, 23);
        NetworkNameTxt.TabIndex = 3;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(447, 31);
        label4.Name = "label4";
        label4.Size = new Size(86, 16);
        label4.TabIndex = 0;
        label4.Text = "Network Name";
        // 
        // menuStrip1
        // 
        menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
        menuStrip1.Location = new Point(0, 0);
        menuStrip1.Name = "menuStrip1";
        menuStrip1.Size = new Size(1146, 24);
        menuStrip1.TabIndex = 7;
        menuStrip1.Text = "menuStrip1";
        // 
        // fileToolStripMenuItem
        // 
        fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { loadToolStripMenuItem, saveToolStripMenuItem, toolStripMenuItem1, exitToolStripMenuItem, importFromToolStripMenuItem });
        fileToolStripMenuItem.Name = "fileToolStripMenuItem";
        fileToolStripMenuItem.Size = new Size(37, 20);
        fileToolStripMenuItem.Text = "&File";
        // 
        // loadToolStripMenuItem
        // 
        loadToolStripMenuItem.Name = "loadToolStripMenuItem";
        loadToolStripMenuItem.Size = new Size(180, 22);
        loadToolStripMenuItem.Text = "&Load";
        loadToolStripMenuItem.Click += LoadToolStripMenuItem_Click;
        // 
        // saveToolStripMenuItem
        // 
        saveToolStripMenuItem.Name = "saveToolStripMenuItem";
        saveToolStripMenuItem.Size = new Size(180, 22);
        saveToolStripMenuItem.Text = "&Save";
        saveToolStripMenuItem.Click += SaveToolStripMenuItem_Click;
        // 
        // toolStripMenuItem1
        // 
        toolStripMenuItem1.Name = "toolStripMenuItem1";
        toolStripMenuItem1.Size = new Size(177, 6);
        // 
        // exitToolStripMenuItem
        // 
        exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        exitToolStripMenuItem.Size = new Size(180, 22);
        exitToolStripMenuItem.Text = "E&xit";
        exitToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
        // 
        // importFromToolStripMenuItem
        // 
        importFromToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { commaSeparatedValuescsvToolStripMenuItem });
        importFromToolStripMenuItem.Name = "importFromToolStripMenuItem";
        importFromToolStripMenuItem.Size = new Size(180, 22);
        importFromToolStripMenuItem.Text = "&Import From";
        // 
        // commaSeparatedValuescsvToolStripMenuItem
        // 
        commaSeparatedValuescsvToolStripMenuItem.Name = "commaSeparatedValuescsvToolStripMenuItem";
        commaSeparatedValuescsvToolStripMenuItem.Size = new Size(241, 22);
        commaSeparatedValuescsvToolStripMenuItem.Text = "&Comma Separated Values (*.csv)";
        commaSeparatedValuescsvToolStripMenuItem.Click += this.commaSeparatedValuescsvToolStripMenuItem_Click;
        // 
        // IpamWindow
        // 
        AcceptButton = CreateNetworkBtn;
        AutoScaleDimensions = new SizeF(7F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1146, 690);
        Controls.Add(NetworkNameTxt);
        Controls.Add(SubnetCbx);
        Controls.Add(NetworkCbx);
        Controls.Add(IpamList);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(IpAddressTxt);
        Controls.Add(RemoveNetworkBtn);
        Controls.Add(CreateNetworkBtn);
        Controls.Add(menuStrip1);
        MainMenuStrip = menuStrip1;
        Name = "IpamWindow";
        Text = "IP Address Manager";
        Load += IpamWindow_Load;
        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button CreateNetworkBtn;
    private TextBox IpAddressTxt;
    private Label label1;
    private Label label2;
    private FlowLayoutPanel IpamList;
    private ComboBox NetworkCbx;
    private Button RemoveNetworkBtn;
    private Label label3;
    private ComboBox SubnetCbx;
    private TextBox NetworkNameTxt;
    private Label label4;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem loadToolStripMenuItem;
    private ToolStripMenuItem saveToolStripMenuItem;
    private ToolStripSeparator toolStripMenuItem1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private ToolStripMenuItem importFromToolStripMenuItem;
    private ToolStripMenuItem commaSeparatedValuescsvToolStripMenuItem;
}
