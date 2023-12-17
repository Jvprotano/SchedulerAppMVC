using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;

namespace AppAgendamentos.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserViewModel, User>();
    }
}