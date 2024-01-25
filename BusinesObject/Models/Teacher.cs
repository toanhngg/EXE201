using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            ClassSchedules = new HashSet<ClassSchedule>();
            TeachingVideos = new HashSet<TeachingVideo>();
        }

        public int TeacherId { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<ClassSchedule> ClassSchedules { get; set; }
        public virtual ICollection<TeachingVideo> TeachingVideos { get; set; }
    }
}
