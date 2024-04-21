namespace TrybeHotel.Dto {
     public class RoomDto {
          public int RoomId { get; set; }
          public string? Name { get; set; }
          public int Capacity { get; set; }
          public string? Image { get; set; }
          public HotelDto? Hotel { get; set; }
     }
}