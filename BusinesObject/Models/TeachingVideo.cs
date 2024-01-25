using System;
using System.Collections.Generic;

namespace BusinesObject.Models
{
    public partial class TeachingVideo
    {
        public TeachingVideo()
        {
            VideoAccesses = new HashSet<VideoAccess>();
        }

        public int VideoId { get; set; }
        public int? CourseId { get; set; }
        public int? TeacherId { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoDescription { get; set; }
        public string? VideoPath { get; set; }
        public DateTime? UploadDate { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual ICollection<VideoAccess> VideoAccesses { get; set; }
    }
}
