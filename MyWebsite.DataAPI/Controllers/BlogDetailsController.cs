using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using AutoMapper;

namespace MyWebsite.DataAPI.Controllers
{
    [ApiController]
    [Route("api/blogdetails")]
    public class BlogDetailsController : GenericController<BlogDetailsDto, BlogDetails>
    {
        private readonly IGenericService<BlogDetailsDto, BlogDetails> _blogDetailsService;
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public BlogDetailsController(IGenericService<BlogDetailsDto, BlogDetails> blogDetailsService, ApplicationDbContext context, IMapper mapper)
            : base(blogDetailsService)
        {
            _blogDetailsService = blogDetailsService;
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("{id}/comments")]
        public async Task<ActionResult<BlogDetailsDto>> GetBlogWithComments(int id)
        {
            var blog = await _context.BlogDetails
                .Include(b => b.CommentList)  
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blog == null)
                return NotFound("Blog bulunamadı.");

            var blogDto = _mapper.Map<BlogDetailsDto>(blog);
            return Ok(blogDto);
        }
    }
}
