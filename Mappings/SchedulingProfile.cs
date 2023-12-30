using AutoMapper;

using Scheduler.Models;
using Scheduler.ViewModels;

namespace Scheduler.Mappings;
public class SchedulingProfile : Profile
{
    public SchedulingProfile()
    {
        CreateMap<Scheduling, SchedulingViewModel>();
        CreateMap<SchedulingViewModel, Scheduling>()
        .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(src => src.ScheduledDate.Date.Add(TimeSpan.Parse(src.TimeSelected))))
        .ForMember(dest => dest.ServicesOfferedId, opt => opt.MapFrom(src => int.Parse(src.ServiceSelected)));
    }
}