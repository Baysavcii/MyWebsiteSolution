using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

namespace MyWebsite.Web.ViewComponents
{
    public class _MyProjectsComponentPartial : ViewComponent
    {
        private readonly IGenericService<MyProjectsDto, MyProjects> _myProjectsService;
        private readonly IMapper _mapper;

        public _MyProjectsComponentPartial(IGenericService<MyProjectsDto, MyProjects> myProjectsService, IMapper mapper)
        {
            _myProjectsService = myProjectsService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _myProjectsService.GetAllAsync();

            if (!result.IsSuccess || result.Value == null || !result.Value.Any())
            {
                ViewBag.ErrorMessage = "Proje bulunamadı.";
                return View(new List<MyProjectsViewModel>());
            }

            var viewModel = _mapper.Map<List<MyProjectsViewModel>>(result.Value);
            return View(viewModel);
        }
    }
}
