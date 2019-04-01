using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class Coord
    {
        [JsonProperty("lat", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Lat { get; set; }

        [JsonProperty("lon", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Lon { get; set; }
    }
}