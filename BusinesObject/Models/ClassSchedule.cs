using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class ClassSchedule
    {
        public ClassSchedule()
        {
            Attendances = new HashSet<Attendance>();
        }

        public int ClassId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public string? Room { get; set; }
        public string? Schedule { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
