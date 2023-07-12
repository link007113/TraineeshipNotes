using CursusCase.Shared.Models;

namespace CursusCase.FrontEnd.Models
{
    public class InstancesCreationDataHolder
    {
        public IEnumerable<CourseInstance> Instances { get; set; }
        public string Message { get; set; }
    }
}