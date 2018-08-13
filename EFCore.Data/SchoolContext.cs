using EFCore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Data.Context
{
    public class SchoolContext : DbContext
    {
		public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
		{
			this.Database.Migrate();
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ClassRoom>()
				.HasOne(c => c.Prefect)
				.WithOne(p => p.Class)
				.HasForeignKey<Teacher>(m => m.ClassId);

			builder.Entity<CourseStudent>().HasKey(p => new { p.CourseId, p.StudentId });

		}

		public DbSet<ClassRoom> ClassRooms { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<CourseStudent> CourseStudents { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Student> Students { get; set; }

	}
}
