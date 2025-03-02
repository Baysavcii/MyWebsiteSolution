using Ardalis.Result;
using Microsoft.Extensions.Configuration;
using MyWebsite.DataAPI.Entities;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class GenericService<TDto, TEntity> : IGenericService<TDto, TEntity>
    where TDto : class
    where TEntity : class
{
    private readonly HttpClient _httpClient;
    private readonly string _resourceUrl;

    public GenericService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;

        var baseUrl = configuration.GetSection("ApiSettings:BaseUrl").Value;
        if (string.IsNullOrEmpty(baseUrl))
            throw new System.Exception("API Base URL is not configured in appsettings.json!");

        if (typeof(TEntity) == typeof(Blog))
        {
            _resourceUrl = $"{baseUrl}/api/blogs"; 
        }
        else
        {
            _resourceUrl = $"{baseUrl}/api/{typeof(TEntity).Name.ToLower()}";
        }
    }



    public async Task<Result<List<TDto>>> GetAllAsync()
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<List<TDto>>(_resourceUrl);
            return result != null ? Result.Success(result) : Result.NotFound();
        }
        catch (HttpRequestException ex)
        {
            return Result.Error($"HTTP Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Result.Error($"Unknown Error: {ex.Message}");
        }
    }

    public async Task<Result<TDto>> GetByIdAsync(int id)
    {
        try
        {
            var result = await _httpClient.GetFromJsonAsync<TDto>($"{_resourceUrl}/{id}");
            return result != null ? Result.Success(result) : Result.NotFound();
        }
        catch (HttpRequestException ex)
        {
            return Result.Error($"HTTP Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            return Result.Error($"Unknown Error: {ex.Message}");
        }
    }

    public async Task<Result<TDto>> CreateAsync(TDto dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync(_resourceUrl, dto);
            if (!response.IsSuccessStatusCode)
                return Result.Error($"Error: {response.StatusCode}");

            var result = await response.Content.ReadFromJsonAsync<TDto>();
            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error: {ex.Message}");
        }
    }

    public async Task<Result<TDto>> UpdateAsync(int id, TDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"{_resourceUrl}/{id}", dto);
            if (!response.IsSuccessStatusCode)
                return Result.Error($"Error: {response.StatusCode}");

            var result = await response.Content.ReadFromJsonAsync<TDto>();
            return Result.Success(result);
        }
        catch (Exception ex)
        {
            return Result.Error($"Error: {ex.Message}");
        }
    }

    public async Task<Result<bool>> DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"{_resourceUrl}/{id}");
            return response.IsSuccessStatusCode ? Result.Success(true) : Result.Error($"Error: {response.StatusCode}");
        }
        catch (Exception ex)
        {
            return Result.Error($"Error: {ex.Message}");
        }
    }
}
