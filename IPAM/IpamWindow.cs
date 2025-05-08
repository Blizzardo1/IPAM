using Microsoft.VisualBasic.Devices;
using Newtonsoft.Json.Bson;
using System.Drawing.Text;
using System.Net;

namespace IPAM;

public partial class IpamWindow : Form {

    private Config _config;
    private SplashScreen? _splash;
    
    public IpamWindow() {
        InitializeComponent();

        _splash = new();
        _splash.Show();
        _splash.UpdateStatus(null);
        Subnet[] subnets = [.. Helper.GenerateSubnets()];
        SubnetCbx.Items.AddRange(subnets);
        SubnetCbx.SelectedIndex = 0;
        _splash.AppendMaximum(1);
        _splash.UpdateStatus("Loaded Subnets", 1);


        _config = Config.Load();
        _splash.UpdateStatus("Loaded Configuration");
        if(_config.Networks is not null && _config.Networks.Count > 0) {
            _splash.AppendMaximum(_config.Networks.Count);
            _config.Networks.ForEach(network => {
                NetworkCbx.Items.Add(network);
                _splash.UpdateStatus($"Added {network.NetworkName}", 1);
            });
            GetNetwork(_config.Networks[0]);
        }
    }

    private void GetNetwork(Network network) {
        IpamList.Controls.Clear(true);
        List<IpItem> items = [];

        _splash?.AppendMaximum(network.IPAddresses!.Length);
        foreach (IpItemDto item in network.IPAddresses!) {
            items.Add(new(ref network, item.DeviceName, item.IPAddress, item.EnrollmentStatus));
            Task.Delay(1);
            _splash?.UpdateStatus($"In Network {network.NetworkName}, Added {item.DeviceName} : {item.IPAddress}", 1);
        }
        IpamList.Controls.AddRange([.. items]);
        if (!NetworkCbx.Items.Contains(network)) {
            NetworkCbx.Items.Add(network);
        }
        
        NetworkCbx.SelectedItem = network;
    }

    private Task<Network>? CreateNetwork(IPAddress ipAddress, Subnet subnet) {

        if (InvokeRequired) {
            return (Task<Network>?)Invoke(CreateNetwork, ipAddress, subnet);
        }

        CancellationToken cancellationToken = new(true);

        object state = new();

        lock (state) {
            try {

                List<IpItemDto> ipItems = [];
                List<IPAddress> ips = [.. Helper.GenerateIPAddresses(ipAddress, subnet.Prefix)];
                ips.ForEach(ip => {
                    Enrollment enrollment = Enrollment.None;
                    if (ip == ips[0]) {
                        enrollment = Enrollment.Cidr;
                    } else if (ip == ips[^1]) {
                        enrollment = Enrollment.Broadcast;
                    }
                    IpItemDto ipItem = new() {
                        DeviceName = enrollment switch {
                            Enrollment.None => "Unassigned",
                            Enrollment.Cidr => "Start (Unusable)",
                            Enrollment.Router => "Router",
                            Enrollment.Broadcast => "Broadcast",
                            Enrollment.Static => "",
                            Enrollment.Leased => "",
                            _ => ""
                        },
                        EnrollmentStatus = enrollment,
                        IPAddress = ip
                    };

                    ipItems.Add(ipItem);
                });

                Network network = new(NetworkNameTxt.Text, subnet) {
                    IPAddresses = [.. ipItems]
                };

                NetworkCbx.Items.Add(network);
                return Task.FromResult(network);
            } catch (Exception ex) {
                MessageBox.Show($"Error: {ex.Message}", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return Task.FromCanceled<Network>(cancellationToken);
            }
        }
    }

    private void ParseCsvData(string file) {
        string[] lines = File.ReadAllLines(file);
        Network? network = Helper.ParseData(lines);

        if (network is null || network.IPAddresses is null) {
            return;
        }
        if (_config is null || _config.Networks is null) {
            MessageBox.Show("You must create a new Network first and ensure that an ID is present as the header of the CSV.", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }

        // Update the network by ID
        Network current = _config.Networks.First(net => net.Id == network.Id);
        if (current is null || current.IPAddresses is null) {
            MessageBox.Show($"No network was found for ID {network.Id}", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }

        List<IpItemDto> items = [.. network.IPAddresses];
        List<IpItemDto> currentNetItems = [.. current.IPAddresses];
        foreach (IpItemDto ip in items) {
            // This index ensures that the current Network and the network Network have that IPAddress
            int index = currentNetItems.FindIndex((iip) => {
                return iip.IPAddress.Equals(ip.IPAddress);
            });

            if (index < 0) {
                MessageBox.Show($"IP Address {ip.IPAddress} not found in list", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            // Set the current DTO by Index
            var dto = current.IPAddresses[index];
            dto.IPAddress = ip.IPAddress;
            dto.DeviceName = ip.DeviceName;
            dto.EnrollmentStatus = ip.EnrollmentStatus;
            currentNetItems[index] = dto;
        }
        if (!_config.Networks.Remove(current)) {
            MessageBox.Show($"Error removing Network {current.NetworkName}", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }

        Network newNetwork = new(current.NetworkName, current.Subnet) { Id = current.Id, IPAddresses = [.. currentNetItems] };
        _config.Networks.Add(newNetwork);
        _config.Save();
        GetNetwork(newNetwork);
    }

    private async void CreateNetworkBtn_Click(object sender, EventArgs e) {
        if (NetworkNameTxt.Text.IsEmpty()) {
            MessageBox.Show("Please specify a network name", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }
        if (!IPAddress.TryParse(IpAddressTxt.Text, out IPAddress? ipAddress)) {
            MessageBox.Show("Invalid IP Address", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            return;
        }

        try {
            Subnet subnet = (Subnet)SubnetCbx.SelectedItem! ?? throw new ArgumentNullException("Invalid Subnet", new Exception());
            Network? network = await Task.Run(() => CreateNetwork(ipAddress, subnet));
            if (network is null || network.IPAddresses is null) {
                MessageBox.Show("Empty Network", "Failed to create Network", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }
            await Task.Delay(1);
            GetNetwork(network);
        } catch(TaskCanceledException tce) {
            // Task Cancelled
        }
    }

    private void IpamWindow_Load(object sender, EventArgs e) {
        _splash?.Close();
        _splash?.Dispose();
        _splash = null;
    }

    private void RemoveNetworkBtn_Click(object sender, EventArgs e) {
        if (NetworkCbx.SelectedItem is not Network network) {
            return;
        }

        IpamList.Controls.Clear(true);
        NetworkCbx.Items.Remove(network);        
    }

    private void NetworkCbx_SelectedIndexChanged(object sender, EventArgs e) {
        if(NetworkCbx.SelectedItem is not Network network) {
            return;
        }

        IpamList.Controls.Clear();
        GetNetwork(network);
    }

    private void LoadToolStripMenuItem_Click(object sender, EventArgs e) {
        _config = Config.Load();
    }

    private void SaveToolStripMenuItem_Click(object sender, EventArgs e) {
        _config ??= new();
        _config.Networks = [.. NetworkCbx.Items.OfType<Network>()];
        _config.Save();
    }


    private void commaSeparatedValuescsvToolStripMenuItem_Click(object sender, EventArgs e) {
        var dlg = new OpenFileDialog() {
            Filter = "Comma-Separated Values (*.csv)|*.csv"
        };

        if(dlg.ShowDialog() is DialogResult.OK) {
            ParseCsvData(dlg.FileName);
        }
    }


    private void ExitToolStripMenuItem_Click(object sender, EventArgs e) {
        Application.Exit();
    }
}
