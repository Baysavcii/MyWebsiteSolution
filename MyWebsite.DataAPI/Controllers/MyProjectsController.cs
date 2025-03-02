using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.Controllers;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

[ApiController]
[Route("api/myprojects")]
public class MyProjectsController : GenericController<MyProjectsDto, MyProjects>
{
    public MyProjectsController(IGenericService<MyProjectsDto, MyProjects> service) : base(service)
    {
    }
}