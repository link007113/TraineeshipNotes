using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CursusCase.Shared.Models
{
    [Index("CursusId", nameof(StartDate), IsUnique = true)]
    public class CourseInstance
    {
        public int Id { get; set; }

        [Required]
        public Course Cursus { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}