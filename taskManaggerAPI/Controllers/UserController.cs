using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskManaggerAPI.Models;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{userId}")]
        public ActionResult<UserDTO> GetUserById(int userId)
        {
            var user = _userService.GetUserById(userId);

            if (user == null)
            {
                return NotFound();
            }

            var userDTO = new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return Ok(userDTO);
        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = _userService.GetAllUsers();

            var usersDTO = users.Select(user => new UserDTO
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            });

            return Ok(usersDTO);
        }
    }
}
