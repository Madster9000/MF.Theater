using System;

namespace MF.Theater.DTO
{
    public class TicketDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public DateTime TicketStartDate { get; set; }
        public DateTime TicketEndDate { get; set; }
    }
}