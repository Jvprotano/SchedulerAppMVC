
using AppAgendamentos.Enums;

namespace AppAgendamentos.Models.Base
{
    public class BaseEntity
    {
public int Id { get; set; }
public StatusEnum Status { get; set; }
public DateTime RegisterDate { get; set; }
public DateTime UpdateDate { get; set; }
    }
}