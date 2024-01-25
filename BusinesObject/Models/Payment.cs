using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class Payment
    {
        public int PaymentId { get; set; }
        public int? EnrollmentId { get; set; }
        public decimal? Amount { get; set; }
        public DateTime? PaymentDate { get; set; }

        public virtual Enrollment? Enrollment { get; set; }
    }
}
