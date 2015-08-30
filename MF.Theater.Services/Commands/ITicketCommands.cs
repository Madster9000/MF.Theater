using MF.Theater.DTO;

namespace MF.Theater.Services.Commands
{
    public interface ITicketCommands
    {
        void Create(PlayPeriodDto request, string userEmail);
    }
}