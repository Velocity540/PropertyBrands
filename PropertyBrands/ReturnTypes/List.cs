using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public class List
    {
        [JsonProperty("dt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Dt { get; set; }

        [JsonProperty("main", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public MainClass Main { get; set; }

        [JsonProperty("weather", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<Weather> Weather { get; set; }

        [JsonProperty("clouds", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Clouds Clouds { get; set; }

        [JsonProperty("wind", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Wind Wind { get; set; }

        [JsonProperty("sys", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Sys Sys { get; set; }

        [JsonProperty("dt_txt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? DtTxt { get; set; }

        [JsonProperty("rain", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Rain Rain { get; set; }

        [JsonProperty("snow", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public Rain Snow { get; set; }
    }
}