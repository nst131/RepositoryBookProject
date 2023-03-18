using Newtonsoft.Json;

namespace Application.User
{
    public class User
    {
        [JsonProperty(PropertyName = "token", Order = 0, Required = Required.Always)]
        public string Token { get; set; }
    }
}
