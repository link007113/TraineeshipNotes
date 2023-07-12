using System.ComponentModel.DataAnnotations;

namespace CursusCase.Shared.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(52)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(52)]
        public string LastName { get; set; }

        public ICollection<CourseInstance> CourseInstances { get; set; }
    }
}