using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

namespace MyWebsite.Web.ViewComponents
{
    public class _BlogDetailsComponentPartial : ViewComponent
    {
        private readonly IGenericService<BlogDetailsDto, BlogDetails> _blogService;
        private readonly IMapper _mapper;

        public _BlogDetailsComponentPartial(IGenericService<BlogDetailsDto, BlogDetails> blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _blogService.GetAllAsync();

            if (!result.IsSuccess || result.Value == null || !result.Value.Any())
            {
                ViewBag.ErrorMessage = "Blog yazısı bulunamadı.";
                return View(new List<BlogDetailsViewModel>());
            }

            var viewModel = _mapper.Map<List<BlogDetailsViewModel>>(result.Value);
            return View(viewModel);
        }
    }

}
