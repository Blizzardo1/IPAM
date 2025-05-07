using Newtonsoft.Json;
using System.Net;

namespace IPAM;

/// <summary>
/// An IP Subnet
/// </summary>
/// <param name="Prefix">The Prefix</param>
public record Subnet([JsonProperty("prefix")]int Prefix) {
    /// <summary>
    /// The Subnet Prefix as a Subnet Mask
    /// </summary>
    [JsonProperty("mask")]
    public IPAddress Mask => Helper.PrefixToSubnet(Prefix);
    public override string ToString() {
        return $"{Mask}/{Prefix}";
    }
}
