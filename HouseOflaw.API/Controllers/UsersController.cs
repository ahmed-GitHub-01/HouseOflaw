using System.Net;
using System.Threading.Tasks;
using HouseOflaw.API.Data;
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

        public UsersController(IDatingRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("AllGetUser")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();
            return Ok(users);
        }

    }
}