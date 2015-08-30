using MF.Theater.DTO;
using MF.Theater.Services.Commands;

namespace MF.Theater.Services.Workflows
{
    public class UpdatePerfomanceWorkflow: IPerfomanceWorkflow
    {
        private readonly IPerfomanceCommands mPerfomanceCommands;
        private readonly IPerfomanceWorkflow mNextStepWorkflow;

        public UpdatePerfomanceWorkflow(IPerfomanceCommands perfomanceCommands, IPerfomanceWorkflow nextStepWorkflow)
        {
            mPerfomanceCommands = perfomanceCommands;
            mNextStepWorkflow = nextStepWorkflow;
        }

        public void ExecuteStep(PerfomanceDto request)
        {
            mPerfomanceCommands.Update(request);
            mNextStepWorkflow.ExecuteStep(request);
        }
    }
}