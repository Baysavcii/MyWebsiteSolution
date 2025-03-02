using Ardalis.Result;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.DataAPI.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWebsite.DataAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenericController<TDto, TEntity> : ControllerBase where TDto : class where TEntity : class
    {
        private readonly IGenericService<TDto, TEntity> _service;

        public GenericController(IGenericService<TDto, TEntity> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<List<TDto>>> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result.Status == ResultStatus.NotFound)
                return NotFound(result.Errors);
            return Ok(result.Value);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TDto>> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            if (result.Status == ResultStatus.NotFound)
                return NotFound(result.Errors);
            return Ok(result.Value);
        }

    }
}
