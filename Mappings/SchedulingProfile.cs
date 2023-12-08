using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;

using AutoMapper;

namespace AppAgendamentos.Mappings
{
    public class SchedulingProfile : Profile
    {
        public SchedulingProfile()
        {
            CreateMap<Scheduling, SchedulingViewModel>();
            CreateMap<SchedulingViewModel, Scheduling>();
        }
    }
}