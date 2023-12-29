using Scheduler.Models;
using Scheduler.ViewModels.Base;

namespace Scheduler.ViewModels;
public class HomeViewModel : BaseViewModel
{
    public IList<Company> Companies { get; set; }

    public HomeViewModel()
    {
        Companies = new List<Company>();
    }
}