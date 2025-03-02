using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

namespace MyWebsite.Web.Controllers
{
    public class CommentsController : Controller
    {
        private readonly IGenericService<CommentsDto, Comments> _commentsService;
        private readonly IMapper _mapper;

        public CommentsController (IGenericService<CommentsDto, Comments> commentsService, IMapper mapper)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _commentsService.GetAllAsync();

            if (!result.IsSuccess || result.Value == null)
                return View(new List<CommentsViewModel>());

            var viewModelList = _mapper.Map<List<CommentsViewModel>>(result.Value);
            return View(viewModelList);
        }
    }
}
