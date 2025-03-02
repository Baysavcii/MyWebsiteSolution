using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebsite.Web.ViewComponents
{
    public class _BlogComponentPartial : ViewComponent
    {
        private readonly IGenericService<BlogDto, Blog> _blogService;
        private readonly IMapper _mapper;

        public _BlogComponentPartial(IGenericService<BlogDto, Blog> blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            try
            {
                var result = await _blogService.GetAllAsync();

                if (!result.IsSuccess)
                {
                    var errorMessages = result.Errors != null ? string.Join(", ", result.Errors) : "Bilinmeyen hata";
                    Console.WriteLine($"IGenericService API Hatası: {errorMessages}");
                }

                if (!result.IsSuccess || result.Value == null || !result.Value.Any())
                {
                    ViewBag.ErrorMessage = "Blog yazısı bulunamadı.";
                    return View(new List<BlogViewModel>());
                }

                var viewModel = _mapper.Map<List<BlogViewModel>>(result.Value);
                return View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                return View(new List<BlogViewModel>());
            }
        }
    }
}
