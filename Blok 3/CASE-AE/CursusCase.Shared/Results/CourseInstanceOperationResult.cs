using CursusCase.Shared.Models;

namespace CursusCase.Shared.Results
{
    public class CourseInstanceOperationResult
    {
        public List<CourseInstance> CursusInstances { get; set; }

        public bool ContainsError => Errors.Count > 0;
        public List<string> Errors { get; set; }

        public int NewCourses { get; set; }
        public int NewInstances { get; set; }

        public CourseInstanceOperationResult()
        {
            Errors = new List<string>();
            CursusInstances = new List<CourseInstance>();
        }
    }
}