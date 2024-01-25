using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class VideoAccess
    {
        public int AccessId { get; set; }
        public int? EnrollmentId { get; set; }
        public int? VideoId { get; set; }

        public virtual Enrollment? Enrollment { get; set; }
        public virtual TeachingVideo? Video { get; set; }
    }
}
