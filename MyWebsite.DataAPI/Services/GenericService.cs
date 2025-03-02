using Ardalis.Result;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyWebsite.DataAPI;
using MyWebsite.DataAPI.Services;

public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity> where TDto : class where TEntity : class
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly DbSet<TEntity> _dbSet;

    public GenericService(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<Result<List<TDto>>> GetAllAsync()
    {
        var entityList = await _dbSet.ToListAsync();
        var dtoList = _mapper.Map<List<TDto>>(entityList);
        return Result<List<TDto>>.Success(dtoList);
    }

    public async Task<Result<TDto>> GetByIdAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return Result<TDto>.NotFound();

        var dto = _mapper.Map<TDto>(entity);
        return Result<TDto>.Success(dto);
    }

    public async Task<Result<TDto>> AddAsync(TDto dto)
    {
        var entity = _mapper.Map<TEntity>(dto);
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        var createdDto = _mapper.Map<TDto>(entity);
        return Result<TDto>.Success(createdDto);
    }

    public async Task<Result<TDto>> UpdateAsync(TDto dto, int id)
    {
        var existingEntity = await _dbSet.FindAsync(id);
        if (existingEntity == null)
            return Result<TDto>.NotFound();

        _mapper.Map(dto, existingEntity);
        await _context.SaveChangesAsync();

        var updatedDto = _mapper.Map<TDto>(existingEntity);
        return Result<TDto>.Success(updatedDto);
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return Result<bool>.NotFound();

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return Result<bool>.Success(true);
    }
}
