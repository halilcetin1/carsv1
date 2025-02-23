using Buisness.Abastraction;
using Buisness.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
 
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }



        [HttpPost("register")]

        public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto model)
        {

            var res = await _userService.Register(model);
            if (res.IsSuccess)
            {
                return Ok(res);
            }
            return BadRequest(res);
        }
  
       









        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto model)
        {
            var res = await _userService.Login(model);
            if (res.IsSuccess) {
                return Ok(res.Result);
            }
            return BadRequest(res);
        }




    






}
}
