using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.Controllers;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

[ApiController]
[Route("api/about")]
public class AboutController : GenericController<AboutDto, About>
{
    public AboutController(IGenericService<AboutDto, About> service) : base(service)
    {
    }
}