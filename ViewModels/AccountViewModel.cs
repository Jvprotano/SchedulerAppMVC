using AppAgendamentos.ViewModels.Base;

namespace AppAgendamentos.ViewModels;
public class AccountViewModel : BaseViewModel
{
    public List<CompanyViewModel> Companies { get; set; }
}