namespace TRG.IO.Services
{
    internal interface IFileService
    {
        void HandleInput(string filePath);
        void ClearData();
    }
}
