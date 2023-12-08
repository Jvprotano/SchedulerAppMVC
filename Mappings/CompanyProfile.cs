using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;

namespace AppAgendamentos.Mappings
{
    public class CompanyProfile : Profile
    {
public CompanyProfile()
{
    CreateMap<Company, CompanyViewModel>();
    CreateMap<Company, SchedulingViewModel>()
    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
    .ForMember(dest => dest.CompanyDescription, opt => opt.MapFrom(src => src.Description))
    .ForMember(dest => dest.CompanyImage, opt => opt.MapFrom(src => src.Image))
    // .ForMember(dest => dest.CompanyServices, opt => opt.MapFrom(src => src.ServicesOffered))
    .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));

}
    }
}