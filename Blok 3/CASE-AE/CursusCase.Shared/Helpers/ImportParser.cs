using CursusCase.Shared.Exceptions;
using CursusCase.Shared.Models;
using System.Globalization;

namespace CursusCase.Shared.Helpers
{
    public class ImportParser
    {
        private bool _isNewBlock;
        private string _errorMessage;

        internal List<CourseInstance> ParseLinesToCursus(string[] lines)
        {
            List<CourseInstance> cursussen = new List<CourseInstance>();
            CourseInstance instance = null;
            _isNewBlock = true;
            int index = 0;

            foreach (string line in lines)
            {
                if (CountElementsUntilEmptyString(lines, index) <= 4)
                {
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        HandleEmptyLine(instance, cursussen);
                    }
                    else
                    {
                        if (_isNewBlock)
                        {
                            if (ValidImportBlock(lines, index))
                            {
                                instance = new();
                                instance.Cursus = new();
                                instance.Students = new List<Student>();
                                _isNewBlock = false;
                            }
                            else
                            {
                                throw new ImportException(
                                    $"Import is not valid: Formatting error in block of line {index + 1}"
                                );
                            }
                        }

                        ParseLine(line, instance);
                    }

                    index++;
                }
                else
                {
                    throw new ImportException($"No NewLine has been found between imports in block of line {index + 1}");
                }
            }
            // Deze is nodig om aan het einde van het bestand niet altijd een witregel zit.
            AddCursusToCollectionIfValid(cursussen, instance);

            return cursussen;
        }

        private bool ValidImportBlock(string[] lines, int index)
        {
            string fieldTitle = ValidateImportLine(lines, index);
            string fieldCode = ValidateImportLine(lines, index + 1);
            string fieldDuration = ValidateImportLine(lines, index + 2);
            string fieldStart = ValidateImportLine(lines, index + 3);

            return fieldTitle.Equals("Titel")
                && fieldCode.Equals("Cursuscode")
                && fieldDuration.Equals("Duur")
                && fieldStart.Equals("Startdatum");
        }

        private static string ValidateImportLine(string[] lines, int index)
        {
            if (lines[index].Contains(':'))
            {
                return lines[index].Substring(0, lines[index].IndexOf(':')).Trim();
            }
            else
            {
                return string.Empty;
            }
        }

        private int CountElementsUntilEmptyString(string[] array, int startIndex)
        {
            int count = 0;
            int index = startIndex;

            while (index < array.Length && !string.IsNullOrWhiteSpace(array[index]))
            {
                count++;
                index++;
            }

            return count;
        }

        private void AddCursusToCollectionIfValid(
            List<CourseInstance> cursussen,
            CourseInstance cursus
        )
        {
            if (cursus != null && ValidateCursus(cursus))
            {
                if (!cursussen.Contains(cursus))
                {
                    cursussen.Add(cursus);
                    _isNewBlock = true;
                }
            }
            else if (cursus != null)
            {
                throw new ImportException(_errorMessage);
            }
        }

        private void HandleEmptyLine(CourseInstance cursus, List<CourseInstance> cursussen)
        {
            AddCursusToCollectionIfValid(cursussen, cursus);
            cursus = null;
            if (!_isNewBlock)
            {
                _errorMessage = "Import has not right format";
            }
        }

        private void ParseLine(string line, CourseInstance cursusInstance)
        {
            int colonIndex = line.IndexOf(':');
            if (colonIndex != -1)
            {
                string field = line.Substring(0, colonIndex).Trim();
                string value = line.Substring(colonIndex + 1).Trim();

                switch (field)
                {
                    case "Titel":
                        cursusInstance.Cursus.Title = value;
                        break;

                    case "Cursuscode":
                        cursusInstance.Cursus.Code = value;
                        break;

                    case "Duur":
                        int duration;
                        if (value.Contains("dagen") && int.TryParse(value.Split()[0], out duration))
                        {
                            cursusInstance.Cursus.DurationInDays = duration;
                        }
                        break;

                    case "Startdatum":
                        DateTime startDate;
                        CultureInfo cultureInfo = new CultureInfo("nl-NL");
                        if (
                            value.Contains('/')
                            && DateTime.TryParse(
                                value,
                                cultureInfo,
                                DateTimeStyles.None,
                                out startDate
                            )
                        )
                        {
                            cursusInstance.StartDate = startDate;
                        }
                        break;
                }
            }
        }

        private bool ValidateCursus(CourseInstance cursusInstance)
        {
            if (string.IsNullOrEmpty(cursusInstance.Cursus.Title))
            {
                _errorMessage = "Title is missing";
                return false;
            }

            if (string.IsNullOrEmpty(cursusInstance.Cursus.Code))
            {
                _errorMessage = "CursusCode is missing";
                return false;
            }

            if (cursusInstance.Cursus.DurationInDays == 0)
            {
                _errorMessage = "Duration is missing";
                return false;
            }

            if (cursusInstance.StartDate == DateTime.MinValue)
            {
                _errorMessage = "Startdatum is missing or has the wrong format";
                return false;
            }
            return true;
        }

        internal List<CourseInstance> ParseLinesToCursus(string[] lines, Period period)
        {
            List<CourseInstance> instanceList = ParseLinesToCursus(lines);
            List<CourseInstance> newlist = new List<CourseInstance>();

            foreach (CourseInstance instance in instanceList)
            {
                if (instance.StartDate > period.DateFrom && instance.StartDate < period.DateTo)
                {
                    newlist.Add(instance);
                }
            }
            return newlist;
        }
    }
}