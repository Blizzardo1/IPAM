using Newtonsoft.Json;
using System.Net;

namespace IPAM;

/// <summary>
/// Represents an IPv4 Network
/// </summary>
/// <param name="NetworkName">The name of the network</param>
/// <param name="Block">A list of IP Addresses</param>
/// <param name="Subnet">The Subnet mask</param>
public record Network([JsonProperty("network-name")]string NetworkName, [JsonProperty("subnet")]Subnet Subnet) {
    /// <summary>
    /// The Classless Inter-Domain Routing IP Address
    /// </summary>
    [JsonProperty("cidr")]
    public IPAddress Cidr => IPAddresses?[0].IPAddress ?? throw new ArgumentNullException("IPAddresses contains no addresses", new Exception());

    /// <summary>
    /// The Broadcast IP Address
    /// </summary>
    [JsonProperty("broadcast")]
    public IPAddress Broadcast => IPAddresses?[^1].IPAddress ?? throw new ArgumentNullException("IPAddresses contains no addresses", new Exception());

    [JsonProperty("ip-addresses")]
    public IpItemDto[]? IPAddresses {  get; set; }

    [JsonProperty("id")]
    public Guid Id { get; set; } = Guid.NewGuid();

    public override string ToString() {
        return $"{NetworkName} : {Cidr}/{Subnet.Prefix}";
    }
}
