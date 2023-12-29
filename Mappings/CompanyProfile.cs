using Scheduler.Enums;
using Scheduler.Models;
using Scheduler.ViewModels;

using AutoMapper;

namespace Scheduler.Mappings;
public class CompanyProfile : Profile
{
    public CompanyProfile()
    {
        CreateMap<Company, CompanyViewModel>();
        CreateMap<CompanyViewModel, Company>()
        .ForMember(dest => dest.Categories, opt => opt.MapFrom((src, dest) =>
        {
            var categories = new List<CompanyCategory>();
            foreach (var category in src.SelectedCategoryIds)
                categories.Add(new CompanyCategory() { CategoryId = (CategoryEnum)category });

            return categories;
        }));

        CreateMap<Company, SchedulingViewModel>()
        .ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.Name))
        .ForMember(dest => dest.CompanyDescription, opt => opt.MapFrom(src => src.Description))
        .ForMember(dest => dest.CompanyImage, opt => opt.MapFrom(src => src.ImageUrl))
        .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ScheduledDate, opt => opt.MapFrom(src => DateTime.Now));
    }
}