using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class MainClass
    {
        [JsonProperty("temp", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Temp { get; set; }

        [JsonProperty("temp_min", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TempMin { get; set; }

        [JsonProperty("temp_max", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TempMax { get; set; }

        [JsonProperty("pressure", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Pressure { get; set; }

        [JsonProperty("sea_level", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? SeaLevel { get; set; }

        [JsonProperty("grnd_level", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? GrndLevel { get; set; }

        [JsonProperty("humidity", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Humidity { get; set; }

        [JsonProperty("temp_kf", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? TempKf { get; set; }
    }
}