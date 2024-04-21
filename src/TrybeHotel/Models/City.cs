namespace TrybeHotel.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class City
    {
    // 1. Adicione o atributo State na model City
        public int CityId { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Hotel>? Hotels { get; set; }
        public string? State { get; set; }
    }
}