using TRG.Models.Model;

namespace TRG.IO.Services
{
    internal interface IFileService
    {
        void HandleInput(string filePath, Grid grid);
    }
}
