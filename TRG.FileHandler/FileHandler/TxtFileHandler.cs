namespace TRG.FileHandler.FileHandler
{
    public class TxtFileHandler : IFileHandler
    {
        public List<string> ReadFile(string filePath) =>
            File.ReadAllLines(filePath).ToList();
    }
}
