using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyWeb.Server.Data;
using PharmacyWeb.Server.Services.AuthService;
using PharmacyWeb.Shared;
using PharmacyWeb.Shared.Models;

namespace PharmacyWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<User>>> Register (UserRegister request)
        {
            var user = await _authService.Register(request);
            if(user != null)
            {
                return Ok(new ServiceResponse<User>()
                {
                    Data = user
                });
            }
            else
            {
                return BadRequest(new ServiceResponse<User>()
                {
                    Success = false,
                    Message = "Имя пользователя занято."
                });
            }
        }
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<User>>> Login(UserLogin request)
        {
            var user = await _authService.Login(request);

            if (user != null)
            {
                return Ok(new ServiceResponse<User>()
                {
                    Data = user
                });
            }
            else
            {
                return BadRequest(new ServiceResponse<User>()
                {
                    Success = false,
                    Message = "Пользователь не найден."
                }); ;
            }

        }
    }
}
