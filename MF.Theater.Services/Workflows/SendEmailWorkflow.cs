using System;
using System.Linq;
using MF.Theater.DTO;
using MF.Theater.Services.Common;
using MF.Theater.Services.Queries;

namespace MF.Theater.Services.Workflows
{
    public class SendEmailWorkflow: IPerfomanceWorkflow
    {
        private readonly ITicketsQueries mTicketsQueries;
        private readonly IEmailSender mEmailSender;

        public SendEmailWorkflow(ITicketsQueries ticketsQueries, IEmailSender emailSender)
        {
            mTicketsQueries = ticketsQueries;
            mEmailSender = emailSender;
        }

        public void ExecuteStep(PerfomanceDto request)
        {
            var tickets = mTicketsQueries.GetPlayperiodsTickets(request.PlayPeriods.ToList());
            foreach (var ticketDto in tickets)
            {
                var message = String.Format("Дата билета была изменена. Новая дата начала {0}, новая дата конца {1}",
                    ticketDto.TicketStartDate, ticketDto.TicketEndDate);
                mEmailSender.SendEmail(ticketDto.Email, message);
            }
        }
    }
}