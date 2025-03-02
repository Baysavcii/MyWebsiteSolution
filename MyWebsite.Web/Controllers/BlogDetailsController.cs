using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Web.Models;
using MyWebsite.DataAPI.DTOs;

namespace MyWebsite.Web.Controllers
{
    public class BlogDetailsController : Controller
    {
        private readonly IGenericService<BlogDetailsDto, BlogDetailsDto> _blogDetailsService;
        private readonly IGenericService<CommentsDto, CommentsDto> _commentsService;
        private readonly IMapper _mapper;

        public BlogDetailsController(
            IGenericService<BlogDetailsDto, BlogDetailsDto> blogDetailsService,
            IGenericService<CommentsDto, CommentsDto> commentsService,
            IMapper mapper)
        {
            _blogDetailsService = blogDetailsService;
            _commentsService = commentsService;
            _mapper = mapper;
        }

        [HttpGet("Blog/Details/{id}")]  // Route'u güncelle!
        public async Task<IActionResult> Details(int id)
        {
            var blogResult = await _blogDetailsService.GetByIdAsync(id);
            if (!blogResult.IsSuccess || blogResult.Value == null)
                return NotFound();

            var blogViewModel = _mapper.Map<BlogDetailsViewModel>(blogResult.Value);

            var commentsResult = await _commentsService.GetAllAsync();
            var commentsList = commentsResult.IsSuccess
                ? _mapper.Map<List<CommentsViewModel>>(commentsResult.Value)
                : new List<CommentsViewModel>();

            blogViewModel.CommentList = commentsList.FindAll(c => c.BlogDetailsId == id);

            return View(blogViewModel);
        }

        public async Task<IActionResult> Index(int id)
        {
            var blogResult = await _blogDetailsService.GetByIdAsync(id);
            if (!blogResult.IsSuccess || blogResult.Value == null)
                return NotFound();

            var blogViewModel = _mapper.Map<BlogDetailsViewModel>(blogResult.Value);

            var commentsResult = await _commentsService.GetAllAsync();
            var commentsList = commentsResult.IsSuccess
                ? _mapper.Map<List<CommentsViewModel>>(commentsResult.Value)
                : new List<CommentsViewModel>();

            blogViewModel.CommentList = commentsList.FindAll(c => c.BlogDetailsId == id);

            return View(blogViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CommentsViewModel model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index", new { id = model.BlogDetailsId });

            var commentDto = _mapper.Map<CommentsDto>(model);
            var result = await _commentsService.CreateAsync(commentDto);

            if (result.IsSuccess)
                return RedirectToAction("Index", new { id = model.BlogDetailsId });

            return View("Error");
        }
    }
}
