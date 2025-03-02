using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.Web.Models;

[Route("api/blogs")]
[ApiController]
public class BlogController : Controller
{
    private readonly IGenericService<BlogDto, Blog> _blogService;
    private readonly IMapper _mapper;

    public BlogController(IGenericService<BlogDto, Blog> blogService, IMapper mapper)
    {
        _blogService = blogService;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _blogService.GetAllAsync();
        if (!result.IsSuccess || result.Value == null)
            return NotFound(new { message = "Blog bulunamadı." });

        return Ok(result.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _blogService.GetByIdAsync(id);
        if (!result.IsSuccess || result.Value == null)
            return NotFound();

        return Ok(result.Value);
    }

    [HttpGet("Blog/Details/{id}")] 
    public async Task<IActionResult> Details(int id)
    {
        var result = await _blogService.GetByIdAsync(id);
        if (!result.IsSuccess || result.Value == null)
            return NotFound();

        var viewModel = _mapper.Map<BlogDetailsViewModel>(result.Value);
        return View (viewModel);
    }
}
