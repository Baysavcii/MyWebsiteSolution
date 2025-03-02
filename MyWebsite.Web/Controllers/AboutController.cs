using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.MVC.Models;

public class AboutController : Controller
{
    private readonly IGenericService<AboutDto, About> _aboutService;
    private readonly IMapper _mapper;

    public AboutController(IGenericService<AboutDto, About> aboutService, IMapper mapper)
    {
        _aboutService = aboutService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _aboutService.GetAllAsync();

        if (!result.IsSuccess || result.Value == null)
            return View(new List<AboutViewModel>());

        var viewModelList = _mapper.Map<List<AboutViewModel>>(result.Value);
        return View(viewModelList);
    }
}
