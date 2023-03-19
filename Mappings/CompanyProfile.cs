using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;

namespace AppAgendamentos.Mappings
{
    public class CompanyProfile : Profile
    {
***REMOVED***public CompanyProfile()
***REMOVED***{
***REMOVED***    CreateMap<Company, CompanyViewModel>();
***REMOVED***    CreateMap<Company, SchedulingViewModel>()
***REMOVED***    .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
***REMOVED***    .ForMember(dest => dest.CompanyDescription, opt => opt.MapFrom(src => src.Description))
***REMOVED***    .ForMember(dest => dest.CompanyImage, opt => opt.MapFrom(src => src.Image))
***REMOVED***    // .ForMember(dest => dest.CompanyServices, opt => opt.MapFrom(src => src.ServicesOffered))
***REMOVED***    .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id));

***REMOVED***}
    }
}