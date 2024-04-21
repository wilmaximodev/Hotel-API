using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class UserRepository : IUserRepository
    {
        protected readonly ITrybeHotelContext _context;
        public UserRepository(ITrybeHotelContext context)
        {
            _context = context;
        }
        public UserDto GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public UserDto Login(LoginDto login)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);            
            return new UserDto
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                UserType = user.UserType
            };
        }
        
        public UserDto Add(UserDtoInsert user)
        {

            var validUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);

            if(validUser != null)
            {
                throw new Exception("User email already exists");
            }

                var newUser = new User
                {
                    Name = user.Name,
                    Email = user.Email,
                    Password = user.Password,
                    UserType = "client"
                };

                _context.Users.Add(newUser);
                _context.SaveChanges();

                return new UserDto
                {
                    UserId = newUser.UserId,
                    Name = newUser.Name,
                    Email = newUser.Email,
                    UserType = newUser.UserType
                };              
        }

        public UserDto GetUserByEmail(string userEmail)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserDto> GetUsers()
        {
            var allUsers = _context.Users
            .Select(user => new UserDto
                {
                    UserId = user.UserId,
                    Name = user.Name,                
                    Email = user.Email,
                    UserType = user.UserType
                });
            return allUsers;    
        }
    }
}