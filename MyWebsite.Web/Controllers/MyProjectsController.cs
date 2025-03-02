using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

public class MyProjectsController : Controller
{
    private readonly IGenericService<MyProjectsDto, MyProjects> _myProjectService;
    private readonly IMapper _mapper;

    public MyProjectsController(IGenericService<MyProjectsDto, MyProjects> myProjectService, IMapper mapper)
    {
        _myProjectService = myProjectService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _myProjectService.GetAllAsync();

        if (!result.IsSuccess || result.Value == null)
            return View(new List<MyProjectsViewModel>());

        var viewModelList = _mapper.Map<List<MyProjectsViewModel>>(result.Value);
        return View(viewModelList);
    }
}
