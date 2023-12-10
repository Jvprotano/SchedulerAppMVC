using AppAgendamentos.Enums;
using AppAgendamentos.ViewModels.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

using System.ComponentModel.DataAnnotations;

namespace AppAgendamentos.ViewModels;
public class CompanyViewModel : BaseViewModel
{
    [Display(Name = "Name")]
    public string Name { get; set; }
    [Display(Name = "Email")]
    public string Email { get; set; }
    public string Description { get; set; }
    [Display(Name = "CNPJ")]
    public string Cnpj { get; set; }
    [Display(Name = "Categories")]
    public List<int> SelectedCategoryIds { get; set; } = [];
    [Display(Name = "Services Offered")]
    public List<string> SelectedServicesNames { get; set; } = [];
    public List<SelectListItem> CategoriesSelectIds { get; set; } = LoadCategories();
    public List<SelectListItem> ServicesOfferedsSelect { get; set; } = [];

    private static List<SelectListItem> LoadCategories()
    {
        List<SelectListItem> categories = new List<SelectListItem>();

        Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>().ToList().ForEach(category => categories.Add(
            new SelectListItem(text: category.ToString(), value: ((int)category).ToString())));

        return categories;
    }
}