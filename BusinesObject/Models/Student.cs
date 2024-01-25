using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Student
    {
        public Student()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int StudentId { get; set; }
        public int? UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public virtual User? User { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
