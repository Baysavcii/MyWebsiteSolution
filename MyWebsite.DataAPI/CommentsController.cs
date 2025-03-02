using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.Controllers;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Services;

[ApiController]
[Route("api/comments")]
public class CommentsController : GenericController<CommentsDto, Comments>
{
    public CommentsController(IGenericService<CommentsDto, Comments> service) : base(service)
    {
    }
}