using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Attendance
    {
        public int AttendanceId { get; set; }
        public int? EnrollmentId { get; set; }
        public int? ClassId { get; set; }
        public DateTime? AttendanceDate { get; set; }
        public bool? IsPresent { get; set; }

        public virtual ClassSchedule? Class { get; set; }
        public virtual Enrollment? Enrollment { get; set; }
    }
}
