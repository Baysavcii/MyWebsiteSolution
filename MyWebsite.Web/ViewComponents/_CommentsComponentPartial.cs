using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

namespace MyWebsite.Web.ViewComponents
{
    public class _CommentsComponentPartial : ViewComponent
    {
        private readonly IGenericService<CommentsDto, Comments> _commentsService;
        private readonly IMapper _mapper;

        public _CommentsComponentPartial(IGenericService<CommentsDto, Comments> commentsService, IMapper mapper)
        {
            _commentsService = commentsService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _commentsService.GetAllAsync();

            if (!result.IsSuccess || result.Value == null || !result.Value.Any())
            {
                ViewBag.ErrorMessage = "Yorum bulunamadı.";
                return View(new List<CommentsViewModel>());
            }

            var viewModel = _mapper.Map<List<CommentsViewModel>>(result.Value);
            return View(viewModel);
        }
    }
}
