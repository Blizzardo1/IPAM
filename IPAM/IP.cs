using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAM;

public partial class IpItem : UserControl {

    private Network _parentNetwork;
    private IpItemDto _ipItem;
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        JsonProperty("data")]
    public IpItemDto? IpData { get => _ipItem; set => _ipItem = value ?? new IpItemDto(); }
    

    public IpItem(ref Network network, string deviceName, IPAddress address, Enrollment enrollmentStatus) {
        _ipItem = new();
        InitializeComponent();
        _parentNetwork = network;
        DeviceNameLbl.Text = deviceName;
        IpAddressLbl.Text = address.ToString();
        EnrollmentStatusLbl.Text = Enum.GetName(enrollmentStatus);
        _ipItem.DeviceName = deviceName;
        _ipItem.IPAddress = address;
        _ipItem.EnrollmentStatus = enrollmentStatus;
        EnrollmentStatusLbl.TextChanged += EnrollmentStatus_TextChanged;
        EnrollmentStatus_TextChanged(this, new());
    }

    private void EnrollmentStatus_TextChanged(object? sender, EventArgs e) {
        BackColor = _ipItem.EnrollmentStatus switch {
            Enrollment.None => Color.FromKnownColor(KnownColor.Control),
            Enrollment.Static => Color.RebeccaPurple,
            Enrollment.Leased => Color.Firebrick,
            Enrollment.Router => Color.RoyalBlue,
            Enrollment.Cidr => Color.IndianRed,
            Enrollment.Broadcast => Color.Goldenrod,
            _ => Color.FromKnownColor(KnownColor.Control)
        };
        ForeColor = Helper.PerceivedBrightness(BackColor) > 130 ? Color.Black : Color.White;
    }

    private void IpItem_Click(object sender, EventArgs e) {
        switch (_ipItem.EnrollmentStatus) {
            case Enrollment.None:
                break;
            case Enrollment.Cidr:
                MessageBox.Show("Cannot change the CIDR Address", "Unable to make change", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            case Enrollment.Broadcast:
                MessageBox.Show("Cannot change the Broadcast Address", "Unable to make change", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            case Enrollment.Static:
                break;
            case Enrollment.Leased:
                break;
            case Enrollment.Router:
                break;
            default:
                MessageBox.Show("Unknown Enrollment Type", "Unable to make change", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                break;
        }
        var eipi = new EditIpItem(_ipItem.DeviceName, _ipItem.EnrollmentStatus);
        if (eipi.ShowDialog() == DialogResult.OK) {
            EnrollmentStatus_TextChanged(this, new());
            List<IpItemDto> items = [.. _parentNetwork.IPAddresses!];
            int index = items.IndexOf(_ipItem);
            _ipItem.DeviceName = eipi.DeviceName;
            _ipItem.EnrollmentStatus = eipi.Enrollment;
            DeviceNameLbl.Text = eipi.DeviceName;
            EnrollmentStatusLbl.Text = Enum.GetName(eipi.Enrollment);
            items[index] = _ipItem;
            _parentNetwork.IPAddresses = [.. items];            
        }
    }
}
