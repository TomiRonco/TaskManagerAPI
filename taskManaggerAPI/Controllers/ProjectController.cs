using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using taskManaggerAPI.Data.Entities;
using taskManaggerAPI.Data.Models;
using taskManaggerAPI.Services.Interfaces;

namespace taskManaggerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;
        private readonly IUserService _userService;

        public ProjectController(IUserService userService, IProjectService projectService)
        {
            _userService = userService;
            _projectService = projectService;
        }

        [HttpGet("GetProjectsCompleted")]
        public IActionResult GetProjectCompleted()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var projects = _projectService.GetProjectCompleted();
                var projectDtos = projects
                    .Where(x => x.State == false)
                    .Select(p => new ProjectGetDto
                    {
                        Id = p.Id,
                        projectName = p.ProjectName,
                        Description = p.Description,
                        adminId = p.AdminId,
                        clientId = p.ClientId,
                        state = p.State
                    })
                    .ToList();

                try
                {
                    return Ok(projectDtos);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpGet("GetProjectsIncompleted")]
        public IActionResult GetProjectIncompleted()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var projects = _projectService.GetProjectIncompleted();
                var projectDtos = projects
                    .Where(x => x.State == true)
                    .Select(p => new ProjectGetDto
                    {
                        Id = p.Id,
                        projectName = p.ProjectName,
                        Description = p.Description,
                        adminId = p.AdminId,
                        clientId = p.ClientId,
                        state = p.State
                    })
                    .ToList();

                try
                {
                    return Ok(projectDtos);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }


        [HttpGet("GetProjectById{id}")]
        public IActionResult GetProjectById(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                var project = _projectService.GetProjectById(id);

                if (project == null)
                {
                    return NotFound($"El proyecto de ID: {id} no fue encontrado");
                }

                var projectDto = new ProjectGetDto
                {
                    Id = project.Id,
                    projectName = project.ProjectName,
                    Description = project.Description,
                    adminId = project.AdminId,
                    clientId = project.ClientId,
                    state = project.State
                };

                try
                {
                    return Ok(projectDto);
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPost("CreateNewProject")]
        public IActionResult CreateProject([FromBody] ProjectPostDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                string adminId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (dto.ProjectName == "string" && dto.Description == "string" && dto.AdminId == 0 && dto.ClientId == 0)
                {
                    return BadRequest("Proyecto no creado, por favor completar los campos");
                }
                try
                {
                    var project = new Project()
                    {
                        ProjectName = dto.ProjectName,
                        Description = dto.Description,
                        AdminId = int.Parse(adminId),
                        ClientId = dto.ClientId
                    };
                    int id = _projectService.CreateProject(project);
                    return Ok($"Proyecto creado exitosamente con id: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("UpdateProject{id}")]
        public IActionResult UpdateProject([FromRoute] int id, [FromBody] ProjectPutDto project)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                if (project.ProjectName == "string" && project.Description == "string")
                {
                    return BadRequest("Proyecto no actualizado, por favor completar los campos");
                }
                var projectToUpdate = _projectService.GetProjectById(id);
                if (projectToUpdate == null)
                {
                    return NotFound($"Proyecto con ID {id} no encontrado");
                }
                try
                {
                    projectToUpdate.ProjectName = project.ProjectName;
                    projectToUpdate.Description = project.Description;

                    projectToUpdate = _projectService.UpdateProject(projectToUpdate);
                    return Ok($"Proyecto actualizado exitosamente");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al actualizar el Proyecto: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpPut("CompleteProject/{id}")]
        public IActionResult CompleteProject(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
                {
                    var existingProject = _projectService.GetProjectById(id);
                    if (existingProject == null)
                    {
                        return NotFound($"No se encontró ningún proyecto con el ID: {id}");
                    }
                    _projectService.CompleteProject(id);
                    return Ok($"Project con ID: {id} completado");
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
