using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Enrollment
    {
        public Enrollment()
        {
            Attendances = new HashSet<Attendance>();
            Payments = new HashSet<Payment>();
            VideoAccesses = new HashSet<VideoAccess>();
        }

        public int EnrollmentId { get; set; }
        public int? StudentId { get; set; }
        public int? CourseId { get; set; }
        public DateTime? EnrollmentDate { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<VideoAccess> VideoAccesses { get; set; }
    }
}
