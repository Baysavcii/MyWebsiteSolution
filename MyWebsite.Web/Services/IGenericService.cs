using Ardalis.Result;
public interface IGenericService<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    Task<Result<List<TDto>>> GetAllAsync();
    Task<Result<TDto>> GetByIdAsync(int id);
    Task<Result<TDto>> CreateAsync(TDto dto);
    Task<Result<TDto>> UpdateAsync(int id, TDto dto);
    Task<Result<bool>> DeleteAsync(int id);
}
