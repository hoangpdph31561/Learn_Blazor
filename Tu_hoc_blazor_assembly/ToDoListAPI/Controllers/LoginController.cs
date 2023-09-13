using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoList_ViewModel;
using ToDoListAPI.Entities;

namespace ToDoListAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly SignInManager<User> _signInManager;
        public LoginController(IConfiguration configuration, SignInManager<User> signInManager)
        {
            _configuration = configuration;
            _signInManager = signInManager;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _signInManager.PasswordSignInAsync(request.UserName, request.Password,false,false);
            if(!result.Succeeded)
            {
                return BadRequest(new LoginResponse
                {
                    Successful = false,
                    Error = "UserName and password are invalid",
                });
            }
            var clain = new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            var expriry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["JwtExpriryInDays"]));
            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtAudience"],
                clain,
                expires: expriry,
                signingCredentials: creds);
            return Ok(new LoginResponse
            {
                Successful = true,
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
