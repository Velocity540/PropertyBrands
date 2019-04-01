using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Sys
    {
        [JsonProperty("pod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Pod? Pod { get; set; }
    }
}