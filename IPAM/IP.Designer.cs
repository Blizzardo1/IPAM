namespace IPAM; 
partial class IpItem {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        IpAddressLbl = new Label();
        EnrollmentStatusLbl = new Label();
        DeviceNameLbl = new Label();
        SuspendLayout();
        // 
        // IpAddressLbl
        // 
        IpAddressLbl.AutoSize = true;
        IpAddressLbl.Font = new Font("Segoe UI Variable Text", 10F);
        IpAddressLbl.Location = new Point(285, 0);
        IpAddressLbl.Name = "IpAddressLbl";
        IpAddressLbl.Size = new Size(114, 19);
        IpAddressLbl.TabIndex = 0;
        IpAddressLbl.Text = "255.255.255.255";
        // 
        // EnrollmentStatusLbl
        // 
        EnrollmentStatusLbl.AutoSize = true;
        EnrollmentStatusLbl.Location = new Point(210, 2);
        EnrollmentStatusLbl.Name = "EnrollmentStatusLbl";
        EnrollmentStatusLbl.Size = new Size(50, 16);
        EnrollmentStatusLbl.TabIndex = 1;
        EnrollmentStatusLbl.Text = "enrolled";
        EnrollmentStatusLbl.Click += IpItem_Click;
        // 
        // DeviceNameLbl
        // 
        DeviceNameLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        DeviceNameLbl.AutoSize = true;
        DeviceNameLbl.Location = new Point(3, 2);
        DeviceNameLbl.Name = "DeviceNameLbl";
        DeviceNameLbl.Size = new Size(76, 16);
        DeviceNameLbl.TabIndex = 2;
        DeviceNameLbl.Text = "Device Name";
        DeviceNameLbl.Click += IpItem_Click;
        // 
        // IpItem
        // 
        AutoScaleDimensions = new SizeF(7F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        BorderStyle = BorderStyle.Fixed3D;
        Controls.Add(DeviceNameLbl);
        Controls.Add(EnrollmentStatusLbl);
        Controls.Add(IpAddressLbl);
        Name = "IpItem";
        Size = new Size(397, 24);
        Click += IpItem_Click;
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Label IpAddressLbl;
    private Label EnrollmentStatusLbl;
    private Label DeviceNameLbl;
}
