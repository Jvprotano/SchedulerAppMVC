using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;

using AutoMapper;

namespace AppAgendamentos.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyViewModel>();
        CreateMap<CompanyViewModel, Company>();

        CreateMap<Company, SchedulingViewModel>()
        .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.CompanyDescription, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.CompanyImage, opt => opt.MapFrom(src => src.ImageUrl))
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));
    }
}