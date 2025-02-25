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

        [HttpPost]
        public async Task<ActionResult<TDto>> Add(TDto dto)
        {
            var result = await _service.AddAsync(dto);
            if (result.Status == ResultStatus.Error)
                return BadRequest(result.Errors);
            return CreatedAtAction(nameof(GetById), new { id = result.Value }, result.Value);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TDto>> Update(int id, TDto dto)
        {
            var result = await _service.UpdateAsync(dto, id);
            if (result.Status == ResultStatus.NotFound)
                return NotFound(result.Errors);
            if (result.Status == ResultStatus.Error)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await _service.DeleteAsync(id);
            if (result.Status == ResultStatus.NotFound)
                return NotFound(result.Errors);
            if (result.Status == ResultStatus.Error)
                return BadRequest(result.Errors);
            return Ok(result.Value);
        }
    }
}
