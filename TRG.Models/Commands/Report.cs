using TRG.Models.Enums;

namespace TRG.Models.Commands
{
    public record Report() : Command(CommandType.Report);
}
