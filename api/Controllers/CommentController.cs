using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.interfaces;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentController(ICommentRepository commentRepository) {
            _commentRepository = commentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var comments = await _commentRepository.GetAllAsync();
            var commentDtos = comments.Select(comment => comment.ToCommentDto()).ToList();
            return Ok(commentDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) {
            var comment = await _commentRepository.GetByIdAsync(id);
            if (comment == null) {
                return NotFound();
            }
            return Ok(comment.ToCommentDto());
        }
        
    }
}