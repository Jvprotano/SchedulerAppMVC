using Scheduler.Models;
using Scheduler.ViewModels;

using AutoMapper;

namespace Scheduler.Mappings;
public class SchedulingProfile : Profile
{
    public SchedulingProfile()
    {
        CreateMap<Scheduling, SchedulingViewModel>().ReverseMap();
    }
}