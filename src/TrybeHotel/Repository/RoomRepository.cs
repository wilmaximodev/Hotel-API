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

        // 7. Refatore o endpoint GET /room
        public IEnumerable<RoomDto> GetRooms(int HotelId)
        {
           throw new NotImplementedException();
        }

        // 8. Refatore o endpoint POST /room
        public RoomDto AddRoom(Room room) {
            throw new NotImplementedException();
        }

        public void DeleteRoom(int RoomId) {
           throw new NotImplementedException();
        }
    }
}