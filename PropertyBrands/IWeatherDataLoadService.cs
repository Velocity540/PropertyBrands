using System.Threading.Tasks;
using PropertyBrands.ReturnTypes;

namespace PropertyBrands
{
    public interface IWeatherDataLoadService
    {
        Task<Welcome> GetWeatherData(string zipCode);
    }
}