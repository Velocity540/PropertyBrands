using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class City
    {
        [JsonProperty("id", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Id { get; set; }

        [JsonProperty("name", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("coord", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Coord Coord { get; set; }

        [JsonProperty("country", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public string Country { get; set; }
    }
}