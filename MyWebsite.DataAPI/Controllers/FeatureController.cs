using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.Services;

namespace MyWebsite.DataAPI.Controllers
{
    [ApiController]
    [Route("api/feature")]
    public class FeatureController : GenericController<FeatureDto, Feature>
    {
        public FeatureController(IGenericService<FeatureDto, Feature> service) : base(service)
        {
        }
    }
}
