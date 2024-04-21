using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            var hotels = _context.Hotels.Select(hotel => new HotelDto
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
                State = hotel.City.State,
            });

            return hotels;
        }
        
        public HotelDto AddHotel(Hotel hotel)
        {
            try
            {
                _context.Hotels.Add(hotel);
                _context.SaveChanges();

                var hotelEntity = _context.Hotels
                    .Include(h => h.City) // Certifique-se de carregar a entidade City
                    .FirstOrDefault(h => h.HotelId == hotel.HotelId)
                    ?? throw new Exception("Hotel Not Found");

                var hotelDto = new HotelDto
                {
                    HotelId = hotelEntity.HotelId,
                    Name = hotelEntity.Name,
                    Address = hotelEntity.Address,
                    CityId = hotelEntity.CityId,
                    CityName = hotelEntity.City.Name, // Acesso direto à propriedade City.Name
                    State = hotelEntity.City.State // Acesso direto à propriedade City.State
                };

                return hotelDto;
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Error while updating database. Please check your data and try again.", ex);
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while adding the hotel. " + e.Message);
            }
        }
    }
}