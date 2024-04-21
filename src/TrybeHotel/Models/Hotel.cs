namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Hotel
{
    public int HotelId { get; set; }
    public string? Name { get; set; }
    public string? Address { get; set; }
    public int CityId { get; set; }
    public City? City { get; set; }
    public ICollection<Room>? Rooms { get; set; }
    public string? State { get; set; }
}