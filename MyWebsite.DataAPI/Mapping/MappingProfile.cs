using AutoMapper;
using MyWebsite.DataAPI.Entities;
using MyWebsite.DataAPI.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<About, AboutDto>().ReverseMap();
        CreateMap<Feature, FeatureDto>().ReverseMap();
        CreateMap<MyProjects, MyProjectsDto>().ReverseMap();
        CreateMap<BlogDetails, BlogDetailsDto>().ReverseMap();
        CreateMap<Comments, CommentsDto>().ReverseMap();
    }
}
