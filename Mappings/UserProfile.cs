using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;

namespace AppAgendamentos.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserViewModel, ApplicationUser>();
        CreateMap<RegisterViewModel, ApplicationUser>();
        CreateMap<LoginViewModel, ApplicationUser>();

        CreateMap<ApplicationUser, AccountViewModel>().ReverseMap();
    }
}