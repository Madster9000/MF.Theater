using System.Collections.Generic;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Queries
{
    public interface ITicketsQueries
    {
        ICollection<TicketDto> GetPlayperiodsTickets(ICollection<PlayPeriodDto> playPeriodDtos);
    }
}