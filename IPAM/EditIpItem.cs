using System.ComponentModel;

namespace IPAM;

public partial class EditIpItem : Form {

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string DeviceName { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Enrollment Enrollment { get; set; }

    public EditIpItem(string deviceName, Enrollment enrollment) {
        InitializeComponent();
        DeviceName = deviceName;
        Enrollment = enrollment;
        DeviceNameTxt.Text = deviceName;
        
        Enrollment[] enrollments = [.. Enum.GetValues<Enrollment>().Except([Enrollment.Cidr, Enrollment.Broadcast])];
        PopulateEnrollments(enrollments);
        EnrollmentCbx.SelectedItem = enrollment;
        DeviceNameTxt.Focus();
    }

    private void PopulateEnrollments(Enrollment[] enrollments) {
        EnrollmentCbx.Items.Clear();
        foreach(Enrollment enrollment in enrollments) {
            EnrollmentCbx.Items.Add(Enum.GetName<Enrollment>(enrollment)!);
        }
    }

    private void OkBtn_Click(object sender, EventArgs e) {
        DeviceName = DeviceNameTxt.Text;
        if(!Enum.TryParse<Enrollment>(EnrollmentCbx.Text, out Enrollment enrollment)) {
            MessageBox.Show("Invalid Enrollment", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }
        Enrollment = enrollment;
        Close();
    }
}
