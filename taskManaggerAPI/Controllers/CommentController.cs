using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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


        [HttpGet("GetCommentById{id}")]
        public IActionResult GetCommentById(int id)
        {
            var comment = _commentService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound($"El comentario de ID: {id} no fue encontrado");
            }

            return Ok(comment);
        }

        [HttpPost("CreateNewComment")]
        public IActionResult CreateComment([FromBody] CommentPostDto dto)
        {
            if (dto.Content == "string" || dto.ClientId == 0 || dto.ProjectId == 0)
            {
                return BadRequest("Comentario no creado, por favor completar los campos");
            }
            try
            {
                var comment = new Comment()
                {
                    Content = dto.Content,
                    ClientId = dto.ClientId,
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


        [HttpDelete("DeleteComment/{id}")]
        public IActionResult DeleteComment(int id)
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

        [HttpPut("UpdateComment{id}")]
        public IActionResult UpdateComment([FromRoute] int id, [FromBody] CommentPutDto comment)
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
    }
}
