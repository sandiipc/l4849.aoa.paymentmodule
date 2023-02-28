using Microsoft.AspNetCore.Mvc;
using PaymentLogInterfce.API.Repositories;

namespace PaymentLogInterfce.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository, ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
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

            var user = await this.userRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);

            if(user != null)
            {
                var token = await this.tokenHandler.CreateTokenAsync(user);

                return Ok(token);
            }

            return BadRequest("Invalid Username or Password.");


        }
    }
}
