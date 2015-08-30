using System.Collections.Generic;
using System.Linq;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Queries
{
    public class TicketQueries: ITicketsQueries
    {
        private readonly IDbContextFactory mDbContextFactory;

        public TicketQueries(IDbContextFactory dbContextFactory)
        {
            mDbContextFactory = dbContextFactory;
        }

        public ICollection<TicketDto> GetPlayperiodsTickets(ICollection<PlayPeriodDto> playPeriodDtos)
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                var playPeriodIds = playPeriodDtos.Select(x => x.Id);

                var tickets =
                    context.Set<PlayPeriod>()
                        .Where(x => playPeriodIds.Contains(x.Id))
                        .SelectMany(x => x.Tickets)
                        .Select(x => new TicketDto
                        {
                            Id = x.Id,
                            Email = x.UserEmail,
                            TicketStartDate = x.PlayPeriod.StartDate,
                            TicketEndDate = x.PlayPeriod.EndDate
                        });
                return tickets.ToList();
            }
        }
    }
}