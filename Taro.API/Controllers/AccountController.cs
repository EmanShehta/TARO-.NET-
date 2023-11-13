using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Taro.API.Dtos;
using Taro.API.Errors;
using Taro.Repository.Services;

namespace Taro.API.Controllers
{
    public class AccountController : BaseController
    {
 
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager ,SignInManager<AppUser> signInManager,ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse))]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return BadRequest(new ApiResponse(400, "Email is already taken"));
            }

            var newUser = new AppUser
            {
                firstName = registerDto.firstName,
                lastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.Email.Split('@')[0]
            };
            var result = await _userManager.CreateAsync(newUser, registerDto.Password);
            if (!result.Succeeded)
            {


                return BadRequest(new ApiResponse(400, "Failed to create user"));
            }


            var token = await _tokenService.CreateTokenAsync(newUser, _userManager);

            var userDto = new UserDto
            {
                firstName = newUser.firstName,
                lastName = newUser.lastName,
                Email = newUser.Email,
                Token = token
            };
            return Ok(userDto);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] loginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized(new ApiResponse(401, "The email address is incorrect."));
            }
            var passwordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!passwordValid)
            {
                return Unauthorized(new ApiResponse(401, "The password is incorrect."));
            }
            var userDto = new UserDto
            {
                firstName = user.firstName,
                lastName = user.lastName,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user, _userManager)
            };

            await _tokenService.CreateTokenAsync(user, _userManager);
            return Ok(userDto);
        }




 

    }
}
