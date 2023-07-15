using Newtonsoft.Json;

namespace MoonlightPGR.Dispatch.Interfaces
{
    public class LoginRsp
    {
        [JsonProperty("code")]
        public uint? Code { get; set; }

        [JsonProperty("token")]
        public string? Token { get; set; }

        [JsonProperty("port")]
        public uint? Port { get; set; }

        [JsonProperty("ip")]
        public string? Ip { get; set; }
    }
}
