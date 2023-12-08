using System.ComponentModel.DataAnnotations;
using AppAgendamentos.Enums;
using AppAgendamentos.ViewModels.Base;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace AppAgendamentos.ViewModels;
public class CompanyViewModel : BaseViewModel
{
    [Display(Name = "Name")]
    public string Name { get; set; }
    public string Description { get; set; }
    [Display(Name = "Category")]
    public int CategoryId { get; set; }
    public List<SelectListItem> Categories { get; set; } = LoadCategories();


    private static List<SelectListItem> LoadCategories()
    {
***REMOVED***List<SelectListItem> categories = new List<SelectListItem>();

***REMOVED***Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>().ToList().ForEach(category => categories.Add(
***REMOVED***    new SelectListItem(text: category.ToString(), value: ((int)category).ToString())));
***REMOVED***
***REMOVED***return categories;
    }
}