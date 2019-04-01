using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Clouds
    {
        [JsonProperty("all", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? All { get; set; }
    }
}