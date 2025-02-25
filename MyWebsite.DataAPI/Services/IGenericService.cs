using Ardalis.Result;
namespace MyWebsite.DataAPI.Services
{
    public interface IGenericService<TDto, TEntity> where TDto : class where TEntity : class
    {
        Task<Result<List<TDto>>> GetAllAsync();
        Task<Result<TDto>> GetByIdAsync(int id);
        Task<Result<TDto>> AddAsync(TDto dto);
        Task<Result<TDto>> UpdateAsync(TDto dto, int id);
        Task<Result<bool>> DeleteAsync(int id);
    }
}
