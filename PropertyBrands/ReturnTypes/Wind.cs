using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Wind
    {
        [JsonProperty("speed", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Speed { get; set; }

        [JsonProperty("deg", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Deg { get; set; }
    }
}