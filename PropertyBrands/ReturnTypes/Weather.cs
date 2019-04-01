using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Weather
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("main", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MainEnum? Main { get; set; }

        [JsonProperty("description", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("icon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Icon { get; set; }
    }
}