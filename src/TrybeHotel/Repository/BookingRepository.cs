using TrybeHotel.Models;
using TrybeHotel.Dto;
using Microsoft.EntityFrameworkCore;

namespace TrybeHotel.Repository
{
    public class BookingRepository : IBookingRepository
    {
        protected readonly ITrybeHotelContext _context;
        public BookingRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public BookingResponse Add(BookingDtoInsert booking, string email)
        {
            var room = _context.Rooms.Find(booking.RoomId);
            var user = _context.Users.First(u => u.Email == email);
            var bookingEntity = new Booking
            {
                RoomId = booking.RoomId,
                GuestQuant = booking.GuestQuant,
                CheckIn = booking.CheckIn,
                CheckOut = booking.CheckOut,
                UserId = user.UserId,
            };

            var newBooking = _context.Bookings.Add(bookingEntity);
            _context.SaveChanges();
            var hotel = _context.Hotels.Find(room.HotelId);
            var city = _context.Cities.FirstOrDefault(c => c.CityId == hotel.CityId);

            return new BookingResponse
            {
                BookingId = newBooking.Entity.BookingId,
                GuestQuant = newBooking.Entity.GuestQuant,
                CheckIn = newBooking.Entity.CheckIn,
                CheckOut = newBooking.Entity.CheckOut,
                Room = new RoomDto
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
                        CityId = hotel.CityId,
                        CityName = city.Name,
                        State = city.State
                    }
                }
            };
        }

        // 10. Refatore o endpoint GET /booking
        public BookingResponse GetBooking(int bookingId, string email)
        {
            var bookingResponse = _context.Bookings
                .Where(b => b.User.Email == email && b.BookingId == bookingId)
                .Select(b => new BookingResponse
                {
                    BookingId = b.BookingId,
                    CheckIn = b.CheckIn,
                    CheckOut = b.CheckOut,
                    GuestQuant = b.GuestQuant,
                    Room = new RoomDto
                    {
                        RoomId = b.Room.RoomId,
                        Name = b.Room.Name,
                        Capacity = b.Room.Capacity,
                        Image = b.Room.Image,
                        Hotel = new HotelDto
                        {
                            HotelId = b.Room.Hotel.HotelId,
                            Name = b.Room.Hotel.Name,
                            Address = b.Room.Hotel.Address,
                            CityId = b.Room.Hotel.CityId,
                            CityName = b.Room.Hotel.City.Name,
                            State = b.Room.Hotel.City.State
                        }
                    }
                }).SingleOrDefault();

            return bookingResponse;
        }

        public Room GetRoomById(int RoomId)
        {
            throw new NotImplementedException();
        }

    }

}