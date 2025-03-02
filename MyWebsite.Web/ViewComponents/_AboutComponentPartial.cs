using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;

using MyWebsite.DataAPI.Entities;
using MyWebsite.MVC.Models;

public class _AboutComponentPartial : ViewComponent
{
    private readonly IGenericService<AboutDto, About> _aboutService;
    private readonly IMapper _mapper;

    public _AboutComponentPartial(IGenericService<AboutDto, About> aboutService, IMapper mapper)
    {
        _aboutService = aboutService;
        _mapper = mapper;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _aboutService.GetAllAsync();
        if (!result.IsSuccess || result.Value == null)
        {
            ViewBag.ErrorMessage = "Hakkımda bilgisi bulunamadı.";
            return View(new AboutViewModel());
        }

        var viewModel = _mapper.Map<AboutViewModel>(result.Value.FirstOrDefault());
        return View(viewModel);
    }
}
