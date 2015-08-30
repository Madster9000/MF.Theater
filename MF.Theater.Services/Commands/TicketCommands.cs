using System;
using System.Linq;
using MF.Theater.Context.Factories;
using MF.Theater.DataModel;
using MF.Theater.DTO;

namespace MF.Theater.Services.Commands
{
    public class TicketCommands: ITicketCommands
    {
        private readonly IDbContextFactory mDbContextFactory;

        public TicketCommands(IDbContextFactory dbContextFactory)
        {
            mDbContextFactory = dbContextFactory;
        }

        public void Create(PlayPeriodDto request, string userEmail)
        {
            using (var context = mDbContextFactory.CreateContext())
            {
                var currentPlayPeriod = context.Set<PlayPeriod>().FirstOrDefault(x => x.Id == request.Id);
                if (currentPlayPeriod == null)
                {
                    throw new ApplicationException("Период не найден");
                }
                currentPlayPeriod.TicketsCapacity--;

                var ticket = new Ticket
                {
                    Id = Guid.NewGuid(),
                    UserEmail = userEmail
                };
                currentPlayPeriod.Tickets.Add(ticket);

                context.SaveChanges();
            }
        }
    }
}