namespace TRG.FileHandler.FileHandler
{
    public class TxtFileHandler : IFileHandler
    {
        public List<string> ReadFile(string filePath)
        {
            return File.ReadAllLines(filePath).ToList();
        }
    }
}
