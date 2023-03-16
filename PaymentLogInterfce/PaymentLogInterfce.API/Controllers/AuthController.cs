using Microsoft.AspNetCore.Mvc;
using PaymentLogInterfce.API.Repositories;

namespace PaymentLogInterfce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IOwnerRepository ownerRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IOwnerRepository ownerRepository, ITokenHandler tokenHandler)
        {
            this.ownerRepository = ownerRepository;
            this.tokenHandler = tokenHandler;
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(Models.DTO.LoginRequest loginRequest)
        {
            if(loginRequest.UserName == null)
            {
                return BadRequest("Username cannot be null or empty.");
            }
            else if(loginRequest.Password == null)
            {
                return BadRequest("Password cannot be null or empty.");
            }

            var owner = await this.ownerRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);

            if(owner != null)
            {
                var token = await this.tokenHandler.CreateTokenAsync(owner);

                return Ok(token);
            }

            return BadRequest("Invalid Username or Password.");


        }
    }
}
