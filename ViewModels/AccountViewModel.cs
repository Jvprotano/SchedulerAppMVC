using Scheduler.ViewModels.Base;

namespace Scheduler.ViewModels;
public class AccountViewModel : BaseViewModel
{
    public List<CompanyViewModel> Companies { get; set; }
}