using System.Collections.Generic;

namespace PropertyBrands
{
    public class WeatherSettings
    {
        public string EndPoint { get; set; }
        public string Key { get; set; }

        public List<ZipCodeIntervals> ZipCodeIntervals { get; set; }
    }
}