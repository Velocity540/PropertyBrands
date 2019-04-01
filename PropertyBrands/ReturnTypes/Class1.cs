using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PropertyBrands.ReturnTypes
{
    public enum Pod
    {
        D,
        N
    }

    public enum MainEnum
    {
        Clear,
        Clouds,
        Rain,
        Snow
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore, DateParseHandling = DateParseHandling.None, Converters = {PodConverter.Singleton, MainEnumConverter.Singleton, new IsoDateTimeConverter {DateTimeStyles = DateTimeStyles.AssumeUniversal}}
        };
    }
}