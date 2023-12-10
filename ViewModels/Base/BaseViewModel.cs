using AppAgendamentos.Enums;

namespace AppAgendamentos.ViewModels.Base;
public class BaseViewModel
{
    public int Id { get; set; }
    public StatusEnum? Status { get; set; }
}