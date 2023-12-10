using AppAgendamentos.Models;
using AppAgendamentos.ViewModels.Base;

namespace AppAgendamentos.ViewModels;
public class HomeViewModel : BaseViewModel
{
    public IList<Company> Companies { get; set; }

    public HomeViewModel()
    {
        Companies = new List<Company>();
    }
}