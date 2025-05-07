using Newtonsoft.Json;

namespace IPAM; 
internal class Config {
    private const string ConfigPath = "ipam.json";

    [JsonProperty("networks")]
    public List<Network>? Networks { get; set; }

    public static Config Load(string path = ConfigPath) {
        if(!File.Exists(path)) {
            return new();
        }
        using var reader = new StreamReader(path);
        string json = reader.ReadToEnd();
        var settings = new JsonSerializerSettings() {
            Formatting = Formatting.Indented
        };
        settings.Converters.Add(new IPAddressConverter());

        Config? config = JsonConvert.DeserializeObject<Config>(json, settings);
        if(config is null) {
            return new();
        }
        return config;
    }

    public void Save(string path = ConfigPath) {
        using var writer = new StreamWriter(path);

        var settings = new JsonSerializerSettings() {
            Formatting = Formatting.Indented
        };
        settings.Converters.Add(new IPAddressConverter());

        string json = JsonConvert.SerializeObject(this, settings);
        writer.WriteLine(json);
    }
}
