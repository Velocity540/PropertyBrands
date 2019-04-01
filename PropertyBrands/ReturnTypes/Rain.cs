using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Rain
    {
        [JsonProperty("3h", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? The3H { get; set; }
    }
}