using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace MyWebsite.DataAPI.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : GenericController<CommentsDto, Comments>
    {
        private readonly IGenericService<CommentsDto, Comments> _commentsService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public CommentsController(
            IGenericService<CommentsDto, Comments> commentsService,
            ApplicationDbContext context,
            IMapper mapper
        ) : base(commentsService)
        {
            _commentsService = commentsService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("blog/{blogId}")]
        public async Task<ActionResult<List<CommentsDto>>> GetCommentsByBlogId(int blogId)
        {
            var comments = await _context.Comments
                .Where(c => c.BlogDetailsId == blogId)
                .ToListAsync();

            if (comments == null || comments.Count == 0)
                return NotFound("Bu bloga ait yorum bulunamadı.");

            return Ok(_mapper.Map<List<CommentsDto>>(comments));
        }

        [HttpPost]
        public async Task<ActionResult<CommentsDto>> AddComment([FromBody] CommentsDto commentDto)
        {
            if (commentDto == null)
                return BadRequest("Yorum bilgisi boş olamaz.");

            var result = await _commentsService.AddAsync(commentDto);
            if (result.Status == Ardalis.Result.ResultStatus.Error)
                return BadRequest(result.Errors);

            return CreatedAtAction(nameof(GetCommentsByBlogId), new { blogId = commentDto.BlogDetailsId }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CommentsDto>> UpdateComment(int id, [FromBody] CommentsDto commentDto)
        {
            if (commentDto == null)
                return BadRequest("Yorum bilgisi eksik.");

            var result = await _commentsService.UpdateAsync(commentDto, id);
            if (result.Status == Ardalis.Result.ResultStatus.NotFound)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteComment(int id)
        {
            var result = await _commentsService.DeleteAsync(id);
            if (result.Status == Ardalis.Result.ResultStatus.NotFound)
                return NotFound(result.Errors);

            return Ok(result.Value);
        }
    }
}
