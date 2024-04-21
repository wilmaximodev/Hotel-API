using Microsoft.AspNetCore.Mvc;


namespace TrybeHotel.Controllers
{
    [ApiController]
    [Route("/")]
    public class StatusController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { message = "online"});
        }
    }
}
