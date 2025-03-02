using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

namespace MyWebsite.DataAPI.Controllers
{

    [ApiController]
    [Route("api/blogs")]
    public class BlogController : GenericController<BlogDto, Blog>
    {
        public BlogController(IGenericService<BlogDto, Blog> service) : base(service)
        {
        }
    }
}
