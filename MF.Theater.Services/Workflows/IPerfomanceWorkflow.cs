using MF.Theater.DTO;

namespace MF.Theater.Services.Workflows
{
    public interface IPerfomanceWorkflow
    {
        void ExecuteStep(PerfomanceDto request);
    }
}