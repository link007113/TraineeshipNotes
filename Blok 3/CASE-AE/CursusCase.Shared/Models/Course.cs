using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CursusCase.Shared.Models
{
    [Index(nameof(Title), IsUnique = true)]
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MaxLength(10)]
        public string Code { get; set; }

        [Required]
        public int DurationInDays { get; set; }
    }
}