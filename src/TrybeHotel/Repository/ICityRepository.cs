using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public interface ICityRepository
    {
        IEnumerable<CityDto> GetCities();
        CityDto AddCity(City city);
        CityDto UpdateCity(City city);
    }
}