using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;

namespace IPAM;

public record struct IpItemDto([JsonProperty("ip-address")] IPAddress IPAddress) : IComparable<IpItemDto> {
    [JsonProperty("device-name")]
    public string DeviceName { get; set; } = "Unassigned";

    [JsonProperty("enrollment"), JsonConverter(typeof(StringEnumConverter))]
    public Enrollment EnrollmentStatus { get; set; } = Enrollment.None;

    public readonly int CompareTo(IpItemDto other) {
        return IPAddress.ToString().CompareTo(other.IPAddress.ToString());
    }
}
