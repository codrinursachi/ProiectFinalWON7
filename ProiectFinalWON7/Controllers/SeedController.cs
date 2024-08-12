using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectFinalWON7.DTOs;
using ProiectFinalWON7.Services;

namespace ProiectFinalWON7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly SeedService seedService;
        public SeedController(SeedService seedService)
        {
            this.seedService = seedService;
        }
        [HttpPost("seed")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(void))]
        public IActionResult Seed()
        {
            seedService.Seed();
            return Created();
        }
    }
}
