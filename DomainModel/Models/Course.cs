using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string CourseCode { get; set; }
        public DateTime CourseEntryDate { get; set; }
        public virtual ICollection<StudentCourse> StudentCourses { get; set; }
        public string status { get; set; }
    }
}
