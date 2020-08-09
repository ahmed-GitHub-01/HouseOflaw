using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HouseOflaw.API.Data;
using HouseOflaw.API.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HouseOflaw.API.Controller
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepo _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepo repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }
        [AllowAnonymous]
        [HttpGet("AllGetUser")]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _repo.GetUsers();
            var UserToReturn = _mapper.Map<IEnumerable<UserForListDto>>(user);
            return Ok(UserToReturn);
        }
        [AllowAnonymous]
        [HttpGet("Getuser/{code}")]
        public async Task<IActionResult> getUser(double code)
        {
            var user = await _repo.GetUser(code);
            var UserToReturn = _mapper.Map<UserForDetailedDto>(user);
            return Ok(UserToReturn);
        }
    }
}