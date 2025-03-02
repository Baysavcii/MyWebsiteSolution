using AutoMapper;
using MyWebsite.DataAPI.DTOs;
using MyWebsite.MVC.Models;
using MyWebsite.Web.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AboutDto, AboutViewModel>()
            .ForMember(dest => dest.BirthDate, opt => opt.MapFrom(src => src.BirthDate.ToShortDateString()));

        CreateMap<BlogDto, BlogViewModel>().ReverseMap(); 
        CreateMap<BlogDetailsDto, BlogDetailsViewModel>().ReverseMap();
        CreateMap<BlogDto, BlogDetailsViewModel>().ReverseMap();
        CreateMap<CommentsDto, CommentsViewModel>().ReverseMap();
        CreateMap<FeatureDto, FeatureViewModel>().ReverseMap();
        CreateMap<MyProjectsDto, MyProjectsViewModel>().ReverseMap();
    }
}
