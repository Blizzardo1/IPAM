namespace IPAM; 
partial class EditIpItem {
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        OkBtn = new Button();
        EnrollmentCbx = new ComboBox();
        DeviceNameTxt = new TextBox();
        label1 = new Label();
        label2 = new Label();
        SuspendLayout();
        // 
        // OkBtn
        // 
        OkBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        OkBtn.DialogResult = DialogResult.OK;
        OkBtn.Location = new Point(304, 65);
        OkBtn.Name = "OkBtn";
        OkBtn.Size = new Size(75, 23);
        OkBtn.TabIndex = 0;
        OkBtn.Text = "&OK";
        OkBtn.UseVisualStyleBackColor = true;
        OkBtn.Click += OkBtn_Click;
        // 
        // EnrollmentCbx
        // 
        EnrollmentCbx.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        EnrollmentCbx.FormattingEnabled = true;
        EnrollmentCbx.Location = new Point(94, 35);
        EnrollmentCbx.Name = "EnrollmentCbx";
        EnrollmentCbx.Size = new Size(285, 24);
        EnrollmentCbx.TabIndex = 2;
        // 
        // DeviceNameTxt
        // 
        DeviceNameTxt.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        DeviceNameTxt.Location = new Point(94, 6);
        DeviceNameTxt.Name = "DeviceNameTxt";
        DeviceNameTxt.Size = new Size(285, 23);
        DeviceNameTxt.TabIndex = 1;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(12, 9);
        label1.Name = "label1";
        label1.Size = new Size(76, 16);
        label1.TabIndex = 3;
        label1.Text = "Device Name";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(24, 38);
        label2.Name = "label2";
        label2.Size = new Size(64, 16);
        label2.TabIndex = 3;
        label2.Text = "Enrollment";
        // 
        // EditIpItem
        // 
        AcceptButton = OkBtn;
        AutoScaleDimensions = new SizeF(7F, 16F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(391, 100);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(DeviceNameTxt);
        Controls.Add(EnrollmentCbx);
        Controls.Add(OkBtn);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "EditIpItem";
        Text = "Edit IP";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private Button OkBtn;
    private ComboBox EnrollmentCbx;
    private TextBox DeviceNameTxt;
    private Label label1;
    private Label label2;
}