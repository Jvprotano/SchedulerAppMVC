using Scheduler.Models;
using Scheduler.ViewModels;
using AutoMapper;

namespace Scheduler.Mappings;
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