namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Booking
{
    public int BookingId { get; set; }
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public int GuestQuant { get; set; }
    public int UserId { get; set; }
    public User? User { get; set; }
    public int RoomId { get; set; }
    public Room? Room { get; set; }
}