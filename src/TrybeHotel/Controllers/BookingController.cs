using Microsoft.AspNetCore.Mvc;
using TrybeHotel.Models;
using TrybeHotel.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using TrybeHotel.Dto;

namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("booking")]
  
    public class BookingController : Controller
    {
        private readonly IBookingRepository _repository;
        public BookingController(IBookingRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        [Authorize(Policy = "Client")]
        public IActionResult Add([FromBody] BookingDtoInsert bookingInsert)
        {
            var user = HttpContext.User.Identity as ClaimsIdentity;
            var email = user?.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var booking = _repository.Add(bookingInsert, email!);
            return Created("", booking);
        }


        [HttpGet("{Bookingid}")]
        [Authorize(Policy = "Client")]
        public IActionResult GetBooking(int Bookingid)
        {
            var token = HttpContext.User.Identity as ClaimsIdentity;
            var email = token?.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            var bookingResponse = _repository.GetBooking(Bookingid, email);
            if (bookingResponse == null)
            {
                return Unauthorized();
            }

            return Ok(bookingResponse);
        }
    }
}