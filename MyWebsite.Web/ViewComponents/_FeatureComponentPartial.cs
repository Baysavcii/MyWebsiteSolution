using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

namespace MyWebsite.Web.ViewComponents
{
    public class _FeatureComponentPartial : ViewComponent
    {
        private readonly IGenericService<FeatureDto, Feature> _featureService;
        private readonly IMapper _mapper;

        public _FeatureComponentPartial(IGenericService<FeatureDto, Feature> featureService, IMapper mapper)
        {
            _featureService = featureService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _featureService.GetAllAsync();

            if (!result.IsSuccess || result.Value == null || !result.Value.Any())
            {
                ViewBag.ErrorMessage = "Özellik bulunamadı.";
                return View(new List<FeatureViewModel>());
            }

            var viewModel = _mapper.Map<List<FeatureViewModel>>(result.Value);
            return View(viewModel);
        }
    }
}
