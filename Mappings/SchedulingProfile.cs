using AppAgendamentos.Models;
using AppAgendamentos.ViewModels;
using AutoMapper;

namespace AppAgendamentos.Mappings
{
    public class SchedulingProfile : Profile
    {
***REMOVED***public SchedulingProfile()
***REMOVED***{
***REMOVED***    CreateMap<Scheduling, SchedulingViewModel>();
***REMOVED***    CreateMap<SchedulingViewModel, Scheduling>();
***REMOVED***}
    }
}