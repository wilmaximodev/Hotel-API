using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class RoomRepository : IRoomRepository
    {
        protected readonly ITrybeHotelContext _context;
        public RoomRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
            
            var rooms = _context.Rooms
                        .Where(r => r.HotelId == HotelId)
                        .Select(r => new RoomDto
                        {
                            RoomId = r.RoomId,
                            Name = r.Name,
                            Capacity = r.Capacity,
                            Image = r.Image,
                            Hotel = new HotelDto
                            {
                                HotelId = r.Hotel.HotelId,
                                Name = r.Hotel.Name,
                                Address = r.Hotel.Address,
                                CityId = r.Hotel.City.CityId,
                                CityName = r.Hotel.City.Name,
                                State = r.Hotel.City.State
                            }
                        });

            return rooms;
        }

        public RoomDto AddRoom(Room room) {
            try
            {
                _context.Rooms.Add(room);
                _context.SaveChanges();

                var hotel = _context.Hotels.FirstOrDefault(h => h.HotelId == room.HotelId)
                            ?? throw new Exception("Hotel Not Found");

                var city = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId)
                            ?? throw new Exception("City Not Found");

                return new RoomDto
                {
                    RoomId = room.RoomId,
                    Name = room.Name,
                    Capacity = room.Capacity,
                    Image = room.Image,
                    Hotel = new HotelDto
                    {
                        HotelId = hotel.HotelId,
                        Name = hotel.Name,
                        Address = hotel.Address,
                        CityId = city.CityId,
                        CityName = city.Name,
                        State = city.State
                    }
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeleteRoom(int RoomId) {
            var room = _context.Rooms.FirstOrDefault(r => r.RoomId == RoomId)
                        ?? throw new Exception("Room Not Found");

            _context.Rooms.Remove(room);
            _context.SaveChanges();
        }
    }
}