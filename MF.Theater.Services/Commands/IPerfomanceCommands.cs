using MF.Theater.DTO;

namespace MF.Theater.Services.Commands
{
    public interface IPerfomanceCommands
    {
        void Create(PerfomanceDto request);
    }
}