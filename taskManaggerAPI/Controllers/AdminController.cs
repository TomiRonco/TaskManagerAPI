using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.Data.Models;
using taskManaggerAPI.DBContext;
using taskManaggerAPI.Services.Implementations;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;
        private readonly IProjectService _projectService;

        public AdminController(IUserService userService, IAdminService adminService, IProjectService projectService)
        {
            _userService = userService;
            _adminService = adminService;
            _projectService = projectService;
        }

        [HttpGet("GetAdminsTrue")]
        public IActionResult GetAdminsTrue()
        {
            var admins = _adminService.GetAdminsTrue();

            try
            {
                return Ok(admins.Where(x => x.State == true));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetAdminsFalse")]
        public IActionResult GetAdminsFalse()
        {
            var admins = _adminService.GetAdminsFalse();

            try
            {
                return Ok(admins.Where(x => x.State == false));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("GetAdminById{id}")]
        public IActionResult GetAdminById(int id)
        {
            var admin = _adminService.GetAdminById(id);

            if (admin == null)
            {
                return NotFound($"El admmin de ID: {id} no fue encontrado");
            }

            return Ok(admin);
        }

        [HttpGet("GetAdminProjects/{adminId}")]
        public IActionResult GetAdminProjects(int adminId)
        {
            try
            {
                var admin = _adminService.GetAdminById(adminId);

                if (admin == null)
                {
                    return NotFound($"El admin de ID: {adminId} no fue encontrado");
                }

                var projects = _projectService.GetAdminProjects(adminId);

                var projectNames = projects.Select(p => p.ProjectName).ToList();

                return Ok(projectNames);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CreateNewAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto dto)
        {
            if (dto.Name == "string" || dto.Email == "string" || dto.UserName == "string" || dto.Password == "string")
            {
                return BadRequest("Admin no creado, por favor completar los campos");
            }
            try
            {
                var admin = new Admin()
                {
                    Email = dto.Email,
                    Name = dto.Name,
                    Password = dto.Password,
                    UserName = dto.UserName,
                    UserType = "Admin"
                };
                int id = _userService.CreateUser(admin);
                return Ok($"Admin creado exitosamente con id: {id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpDelete("DeleteAdmin/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            try
            {
                var existingAdmin = _adminService.GetAdminById(id);
                if (existingAdmin == null)
                {
                    return NotFound($"No se encontró ningún Admin con el ID: {id}");
                }
                _userService.DeleteUser(id);
                return Ok($"Admin con ID: {id} eliminado");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("UpdateAdmin{id}")]
        public IActionResult UpdateAdmin([FromRoute] int id, [FromBody] AdminPutDto admin)
        {
            if (admin.Name == "string" || admin.Email == "string" || admin.UserName == "string" || admin.Password == "string")
            {
                return BadRequest("Admin no actualizado, por favor completar los campos");
            }
            var adminToUpdate = _adminService.GetAdminById(id);
            if (adminToUpdate == null)
            {
                return NotFound($"Admin con ID {id} no encontrado");
            }
            try
            {
                adminToUpdate.Name = admin.Name;
                adminToUpdate.Email = admin.Email;
                adminToUpdate.Password = admin.Password;
                adminToUpdate.UserName = admin.UserName;

                adminToUpdate = _adminService.UpdateAdmin(adminToUpdate);
                return Ok($"Admin actualizado exitosamente");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error al actualizar el Admin: {ex.Message}");
            }
        }

    }
}
