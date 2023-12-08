using AppAgendamentos.Models;
using AppAgendamentos.ViewModels.Base;

namespace AppAgendamentos.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
public IEnumerable<Company> Companies { get; set; }

public HomeViewModel(){
    Companies = new List<Company>();
}
    }
}