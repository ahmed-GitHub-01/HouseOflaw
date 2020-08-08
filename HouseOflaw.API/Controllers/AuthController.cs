using System.Dynamic;
using System.Security.Claims;
using System.Threading.Tasks;
using HouseOflaw.API.Data;
using HouseOflaw.API.Dtos;
using HouseOflaw.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace HouseOflaw.API.Controller
{
    [Route("[Controller]")]
    [ApiController]
    [Authorize]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepo repo, IConfiguration config)
        {
            _repo = repo;
            _config = config;
        }
        [HttpPost("paraaregistrey")]
        public async Task<IActionResult> Registrey(UserForRegisterDto userForRegister)
        {
            if (await _repo.UserExists(userForRegister.Code))
            {
                return BadRequest("هذا المستخدم مسجل من قبل");
            }
            var userToCreate = new User
            {
                Code = userForRegister.Code,
                UserName = userForRegister.UserName,
                Email = userForRegister.Email,
                Name_Ar = userForRegister.Name_Ar,
                DateEntry = userForRegister.DateEntry,
                Department = userForRegister.Department,
                IsVoke = userForRegister.IsVoke,
                Switch = userForRegister.Switch,
                Response = userForRegister.Response,
                Acc_Code = userForRegister.Acc_Code,
            };
            var CreatedUser = await _repo.Register(userToCreate, userForRegister.Password);
            return StatusCode(201);
        }
        [HttpPost("perlogin")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userFromRepo = await _repo.Login(userForLoginDto.Code, userForLoginDto.Password);
            if (userFromRepo == null) { return Unauthorized(); }
            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier,userFromRepo.ID.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.Code.ToString()),
                new Claim(ClaimTypes.Name,userFromRepo.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Token").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(10),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = userFromRepo.UserName.ToString();
            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
        }
    }
}