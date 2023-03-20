using AppAgendamentos.Contracts.Repository;
using AppAgendamentos.Infrastructure;

namespace AppAgendamentos.Repository
{
    public class SchedulingRepository : ISchedulingRepository
    {
***REMOVED***private readonly ApplicationDbContext _context;

***REMOVED***public SchedulingRepository(ApplicationDbContext context)
***REMOVED***{
***REMOVED***    _context = context;
***REMOVED***}

***REMOVED***public List<DateTime> GetAvailableTimes(DateTime date)
***REMOVED***{
***REMOVED***    // var query = this._context.Schedulings;

***REMOVED***    // Company 
***REMOVED***    // Horário de abertura no dia da semana desta empresa
***REMOVED***    // Gerar uma lista dos horários do dia de 30 em 30 min
***REMOVED***    // Agendamentos já realizados neste dia e nesta empresa. Pegar horário início e duration do serviço
***REMOVED***    // Remover os horários ocupados da lista
***REMOVED***    // Filtrar horários em que o próximo horário seja maior ou igual a duração do serviço selecionado
***REMOVED***    throw new NotImplementedException();
***REMOVED***}
    }
}