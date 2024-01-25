using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Course
    {
        public Course()
        {
            ClassSchedules = new HashSet<ClassSchedule>();
            Enrollments = new HashSet<Enrollment>();
            TeachingVideos = new HashSet<TeachingVideo>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public string? Level { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<TeachingVideo> TeachingVideos { get; set; }
    }
}
