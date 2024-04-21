namespace TrybeHotel.Dto
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserType { get; set; }
    }

    public class UserDtoInsert
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
    
    public class LoginDto
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}