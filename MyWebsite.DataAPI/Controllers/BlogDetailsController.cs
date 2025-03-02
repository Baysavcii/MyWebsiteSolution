using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

namespace MyWebsite.DataAPI.Controllers
{
    [ApiController]
    [Route("api/blogdetails")]
    public class BlogDetailsController : GenericController<BlogDetailsDto, BlogDetails>
    {
        public BlogDetailsController(IGenericService<BlogDetailsDto, BlogDetails> service) : base(service)
        {
        }
    }

}
