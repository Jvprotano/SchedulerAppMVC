using AppAgendamentos.Models;
using AppAgendamentos.ViewModels.Base;

namespace AppAgendamentos.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
***REMOVED***public IEnumerable<Company> Companies { get; set; }

***REMOVED***public HomeViewModel(){
***REMOVED***    Companies = new List<Company>();
***REMOVED***}
    }
}