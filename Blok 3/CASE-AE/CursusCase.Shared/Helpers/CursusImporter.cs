using CursusCase.Shared.Models;

namespace CursusCase.Shared.Helpers
{
    public class CursusImporter
    {
        public List<CourseInstance> Import(string filePath, Period? period = null)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Following file has not been found: {filePath}");
            }

            string[] lines = File.ReadAllLines(filePath);
            ImportParser parser = new ImportParser();

            return period != null ? parser.ParseLinesToCursus(lines, period) : parser.ParseLinesToCursus(lines);
        }
    }
}