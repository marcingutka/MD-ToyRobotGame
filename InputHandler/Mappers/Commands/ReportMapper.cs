using TRG.Models.Commands;

namespace TRG.InputHandler.Mappers.Commands
{
    internal class ReportMapper : IMapCommand
    {
        public Command Map(List<string> parameters) =>
            parameters == null ? new Report() : null;
    }
}
