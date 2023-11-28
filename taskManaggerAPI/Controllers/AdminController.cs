using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpGet("GetAdmins")]
        public IActionResult GetAdmins()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin") 
            {
                try
                {
                var admins = _adminService.GetAdmins();

                    var adminDtos = admins
                       .Where(x => x.State == true)
                       .Select(admin => new AdminsDto
                       {
                           Id = admin.Id,
                           Role = admin.UserType,
                           Name = admin.Name,
                           UserName = admin.UserName,
                           Email = admin.Email,
                           State = admin.State,
                       });
                    return Ok(adminDtos);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpGet("GetAdminById{id}")]
        public IActionResult GetAdminById(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var admin = _adminService.GetAdminById(id);

                if (admin == null)
                {
                    return NotFound($"El admin de ID: {id} no fue encontrado");
                }

                var adminDto = new AdminsDto
                {
                    Id = admin.Id,
                    Role = admin.UserType,
                    Name = admin.Name,
                    UserName = admin.UserName,
                    Email = admin.Email,
                    State = admin.State,
                };
                return Ok(adminDto);
            }
            return Forbid();
        }

        [HttpGet("GetAdminProjects/{adminId}")]
        public IActionResult GetAdminProjects(int adminId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var admin = _adminService.GetAdminById(adminId);

                if (admin == null)
                {
                    return NotFound($"El admin de ID: {adminId} no fue encontrado");
                }

                var projects = _projectService.GetAdminProjects(adminId);

                var adminWithProjects = new AdminProjectsDto
                {
                    AdminId = admin.Id,
                    AdminName = admin.Name,
                    Projects = projects.Select(p => new ProjectDto
                    {
                        ProjectId = p.Id,
                        ProjectName = p.ProjectName
                    }).ToList()
                };
                return Ok(adminWithProjects);
            }
            return Forbid();
        }

        [HttpPost("CreateNewAdmin")]
        public IActionResult CreateAdmin([FromBody] AdminPostDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (dto.Name == "string" && dto.Email == "string" && dto.UserName == "string" && dto.Password == "string")
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
            return Forbid();
        }

        [HttpPut("UpdateAdmin{id}")]
        public IActionResult UpdateAdmin([FromRoute] int id, [FromBody] AdminPutDto admin)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (admin.Name == "string" && admin.Email == "string" && admin.UserName == "string" && admin.Password == "string")
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
            return Forbid();
        }

        [HttpDelete("DeleteAdmin/{id}")]
        public IActionResult DeleteAdmin(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
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
            return Forbid();
        }
    }
}
