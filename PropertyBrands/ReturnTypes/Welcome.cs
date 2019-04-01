using System.Collections.Generic;
using Newtonsoft.Json;

namespace PropertyBrands.ReturnTypes
{
    public partial class Welcome
    {
        [JsonProperty("cod", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(ParseStringConverter))]
        public long? Cod { get; set; }

        [JsonProperty("message", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public double? Message { get; set; }

        [JsonProperty("cnt", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public long? Cnt { get; set; }

        [JsonProperty("list", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public List<List> List { get; set; }

        [JsonProperty("city", Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public City City { get; set; }
    }
}