using System.Net;

namespace IPAM;

internal static class Helper {

    private static bool PokeFail { get; set; }

    private static void PokeValue(ref Network network, int index, string[] line, Enrollment enrollment = Enrollment.None) {
        if (network.IPAddresses is null) {
            MessageBox.Show("List of IP Addresses is not found.", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            PokeFail = true;
            return;
        }

        if (!IPAddress.TryParse(line[2], out IPAddress? address) || address is null) {
            MessageBox.Show($"Invalid IP Address at line {index + 1}", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            PokeFail = true;
            return;
        }

        network.IPAddresses[index] = new IpItemDto(address) {
            IPAddress = address
        };

        if (enrollment != Enrollment.None) {
            network.IPAddresses[index].EnrollmentStatus = enrollment;
            return;
        }
        if(!Enum.TryParse<Enrollment>(line[1], out enrollment)) {
            MessageBox.Show($"Invalid Enrollment Status at line {index + 1}", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            PokeFail = true;
            return;
        }

        network.IPAddresses[index].DeviceName = line[0];
        network.IPAddresses[index].EnrollmentStatus = enrollment;

    }


    /// <summary>
    /// Parses a Comma-Separated Value array
    /// </summary>
    /// <param name="data">The CSV Array to parse</param>
    /// <remarks>Must be Name,Enrollment,IP formatted. The First line must be GUID,Address,Prefix e.g aa790c3e-9412-40d4-9422-29683f4b30c4,8,10.0.0.0</remarks>
    /// <returns>A <see cref="Network"/> containing all the entries specified by the <paramref name="data"/></returns>
    public static Network? ParseData(string[] data) {
        Network network = new("DummyInit", new(0));
        PokeFail = false;
        for (int i = 0; i < data.Length; i++) {
            if(PokeFail) {
                return null;
            }
            string s = data[i];
            string[] line = s.Split(',');
            if (int.TryParse(line[1], out int prefix)) {
                if (prefix is < 0 or > 32) {
                    MessageBox.Show("Invalid Prefix", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return null;
                }
                network = new("Imported", new(prefix)) {
                    IPAddresses = new IpItemDto[data.Length]
                };

                if (!Guid.TryParse(line[0], out Guid id)) {
                    MessageBox.Show("Invalid ID", null, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                    return null;
                }

                network.Id = id;
                PokeValue(ref network, 0, line, Enrollment.Cidr);
                continue;
            }
            PokeValue(ref network, i, line);
        }
        return network;
    }

    /// <summary>
    /// Gets the perceived brightness of a color
    /// </summary>
    /// <remarks>This function takes the SquareRoot of Red^2, Green^2, and Blue^2 multiplied by fractions</remarks>
    /// <param name="color">The Color to check brightness</param>
    /// <returns>A Brightness value</returns>
    public static int PerceivedBrightness(Color color) {
        return (int)Math.Sqrt(
        color.R * color.R * .241 +
        color.G * color.G * .691 +
        color.B * color.B * .068);
    }

    /// <summary>
    /// Converts a Subnet Prefix into its <see cref="IPAddress"/> variant
    /// </summary>
    /// <param name="prefix">The Prefix</param>
    /// <returns>An <see cref="IPAddress"/> as a Subnet Mask</returns>
    public static IPAddress PrefixToSubnet(int prefix) {
        const int Prefix = 32;
        if (prefix < 0 || prefix > 32) {
            return IPAddress.None;
        }
        uint addr = 0;
        int pfx = Prefix;
        while (pfx > Prefix - prefix) {
            addr += (uint)(1 << --pfx) & uint.MaxValue;
        }
        byte[] mask = [
            (byte)((addr >> 24) & 255),
            (byte)((addr >> 16) & 255),
            (byte)((addr >> 8) & 255),
            (byte)(addr & 255),
        ];
        string addrStr = $"{mask[0]}.{mask[1]}.{mask[2]}.{mask[3]}";
        return IPAddress.Parse(addrStr);
    }

    /// <summary>
    /// Converts a Subnet Mask to Prefix
    /// </summary>
    /// <param name="subnet">A Subnet Mask e.g. 255.255.255.0</param>
    /// <returns>The Subnet Prefix from IP Address</returns>
    public static int SubnetToPrefix(IPAddress subnet) {
        byte[] subnetBytes = subnet.GetAddressBytes();
        int prefixLen = 0;
        foreach (byte b in subnetBytes) {
            if (b == 255) {
                prefixLen += 8;
                continue;
            }

            int bit = 7;
            while (bit >= 0 && (b & (1 << bit)) != 0) {
                prefixLen++;
                bit--;
            }
        }
        return prefixLen;
    }

    /// <summary>
    /// Generates an array of <see cref="Subnet"/>
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of Subnets </returns>
    public static IEnumerable<Subnet> GenerateSubnets() {
        for(int i = 32; i >= 0; i--) {
            yield return new Subnet(i);
        }
    }

    /// <summary>
    /// Generates an array of <see cref="IPAddress"/>
    /// </summary>
    /// <param name="cidr">The Classless Inter-Domain Routing IP Address</param>
    /// <param name="prefix">The Subnet Prefix</param>
    /// <returns></returns>
    public static IEnumerable<IPAddress> GenerateIPAddresses(IPAddress cidr, int prefix) {
        ValidateIpAddress(cidr);
        return GenerateIPAddressesIterator(cidr, prefix);
    }

    private static void ValidateIpAddress(IPAddress cidr) {
        if (cidr.GetAddressBytes().Length != 4) {
            throw new ArgumentException("Only IPv4 addresses are supported");
        }
    }

    /// <summary>
    /// Generates an array of <see cref="IPAddress"/>
    /// </summary>
    /// <param name="cidr">The Classless Inter-Domain Routing IP Address</param>
    /// <param name="prefix">The Subnet Prefix</param>
    /// <returns></returns>
    private static IEnumerable<IPAddress> GenerateIPAddressesIterator(IPAddress cidr, int prefix) {
        byte[] ipBytes = cidr.GetAddressBytes();

        // Calculate number of hosts
        int hostBits = 32 - prefix;
        long numHosts = 1L << hostBits; // 2^hostBits

        // Calculate network and broadcast addresses
        uint ipAsInt = BitConverter.ToUInt32(ipBytes.Reverse().ToArray(), 0);
        uint mask = ~(uint.MaxValue >> prefix);
        uint network = ipAsInt & mask;
        uint broadcast = network + (uint)(numHosts - 1);

        // Generate all IP addresses in range
        for (uint i = network; i <= broadcast; i++) {
            byte[] bytes = BitConverter.GetBytes(i).Reverse().ToArray();
            yield return new IPAddress(bytes);
        }
    }
}