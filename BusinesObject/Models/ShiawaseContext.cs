using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinesObject.Models
{
    public partial class ShiawaseContext : DbContext
    {
        public ShiawaseContext()
        {
        }

        public ShiawaseContext(DbContextOptions<ShiawaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<ClassSchedule> ClassSchedules { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Enrollment> Enrollments { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;
        public virtual DbSet<TeachingVideo> TeachingVideos { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VideoAccess> VideoAccesses { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Shiawase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");

                entity.Property(e => e.AttendanceDate).HasColumnType("date");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ClassId)
                    .HasConstraintName("FK__Attendanc__Class__49C3F6B7");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK__Attendanc__Enrol__48CFD27E");
            });

            modelBuilder.Entity<ClassSchedule>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PK__ClassSch__CB1927A0CBE08847");

                entity.Property(e => e.ClassId).HasColumnName("ClassID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.Room).HasMaxLength(50);

                entity.Property(e => e.Schedule).HasMaxLength(100);

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__ClassSche__Cours__44FF419A");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.ClassSchedules)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__ClassSche__Teach__45F365D3");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.CourseName).HasMaxLength(100);

                entity.Property(e => e.Level).HasMaxLength(20);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Message).HasColumnType("text");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.EnrollmentDate).HasColumnType("date");

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__Enrollmen__Cours__4222D4EF");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Enrollments)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__Enrollmen__Stude__412EB0B6");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.PaymentDate).HasColumnType("date");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK__Payments__Enroll__4CA06362");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Students__UserID__398D8EEE");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Teachers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Teachers__UserID__3C69FB99");
            });

            modelBuilder.Entity<TeachingVideo>(entity =>
            {
                entity.HasKey(e => e.VideoId)
                    .HasName("PK__Teaching__BAE5124AE1699276");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.Property(e => e.CourseId).HasColumnName("CourseID");

                entity.Property(e => e.TeacherId).HasColumnName("TeacherID");

                entity.Property(e => e.UploadDate).HasColumnType("date");

                entity.Property(e => e.VideoPath).HasMaxLength(255);

                entity.Property(e => e.VideoTitle).HasMaxLength(100);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.TeachingVideos)
                    .HasForeignKey(d => d.CourseId)
                    .HasConstraintName("FK__TeachingV__Cours__59FA5E80");

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.TeachingVideos)
                    .HasForeignKey(d => d.TeacherId)
                    .HasConstraintName("FK__TeachingV__Teach__5AEE82B9");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.UserRole).HasMaxLength(20);
            });

            modelBuilder.Entity<VideoAccess>(entity =>
            {
                entity.HasKey(e => e.AccessId)
                    .HasName("PK__VideoAcc__4130D0BF874794BE");

                entity.ToTable("VideoAccess");

                entity.Property(e => e.AccessId).HasColumnName("AccessID");

                entity.Property(e => e.EnrollmentId).HasColumnName("EnrollmentID");

                entity.Property(e => e.VideoId).HasColumnName("VideoID");

                entity.HasOne(d => d.Enrollment)
                    .WithMany(p => p.VideoAccesses)
                    .HasForeignKey(d => d.EnrollmentId)
                    .HasConstraintName("FK__VideoAcce__Enrol__5DCAEF64");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.VideoAccesses)
                    .HasForeignKey(d => d.VideoId)
                    .HasConstraintName("FK__VideoAcce__Video__5EBF139D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
