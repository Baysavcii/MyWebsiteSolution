using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

public class FeatureController : Controller
{
    private readonly IGenericService<FeatureDto, Feature> _featureService;
    private readonly IMapper _mapper;

    public FeatureController(IGenericService<FeatureDto, Feature> featureService, IMapper mapper)
    {
        _featureService = featureService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _featureService.GetAllAsync();

        if (!result.IsSuccess || result.Value == null)
            return View(new List<FeatureViewModel>());

        var viewModelList = _mapper.Map<List<FeatureViewModel>>(result.Value);
        return View(viewModelList);
    }
}
