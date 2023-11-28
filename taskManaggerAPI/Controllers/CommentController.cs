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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;

        public CommentController(IUserService userService, ICommentService commentService)
        {
            _userService = userService;
            _commentService = commentService;
        }

        [HttpGet("GetCommentsByProjectId/{projectId}")]
        public IActionResult GetCommentsByProjectId(int projectId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Admin")
            {
                try
                {
                    var comments = _commentService.GetCommentsByProjectId(projectId);

                    if (comments == null || !comments.Any())
                    {
                        return NotFound($"No se encontraron comentarios para el proyecto con ID: {projectId}");
                    }

                    var commentDtos = comments.Select(comment => new CommentDto
                    {
                        Id = comment.Id,
                        Content = comment.Content,
                        ClientId = comment.ClientId
                    }).ToList();

                    return Ok(commentDtos);
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al obtener comentarios por ID de proyecto: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpPost("CreateNewComment")]
        public IActionResult CreateComment([FromBody] CommentPostDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Client")
            {
                string clientId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (dto.Content == "string" && dto.ClientId == 0 && dto.ProjectId == 0)
                {
                    return BadRequest("Comentario no creado, por favor completar los campos");
                }
                try
                {
                    var comment = new Comment()
                    {
                        Content = dto.Content,
                        ClientId = int.Parse(clientId),
                        ProjectId = dto.ProjectId
                    };
                    int id = _commentService.CreateComment(comment);
                    return Ok($"Comentario creado exitosamente con id: {id}");
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }
            return Forbid();
        }

        [HttpPut("UpdateComment/{id}")]
        public IActionResult UpdateComment([FromRoute] int id, [FromBody] CommentPutDto comment)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Client")
            {
                if (comment.Content == "string")
                {
                    return BadRequest("Comentario no actualizado, por favor completar los campos");
                }
                var commentToUpdate = _commentService.GetCommentById(id);
                if (commentToUpdate == null)
                {
                    return NotFound($"Comentario con ID {id} no encontrado");
                }
                try
                {
                    commentToUpdate.Content = comment.Content;

                    commentToUpdate = _commentService.UpdateComment(commentToUpdate);
                    return Ok($"Comentario actualizado exitosamente");
                }
                catch (Exception ex)
                {
                    return BadRequest($"Error al actualizar el Comentario: {ex.Message}");
                }
            }
            return Forbid();
        }

        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Client")
            {
                try
                {
                    var existingComment = _commentService.GetCommentById(id);
                    if (existingComment == null)
                    {
                        return NotFound($"No se encontró ningún comentario con el ID: {id}");
                    }
                    _commentService.DeleteComment(id);
                    return Ok($"Comentario con ID: {id} eliminado");
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
