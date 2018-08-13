using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Data.Models
{
    public class CourseStudent
    {

		public Guid StudentId { get; set; }
		public Student Student { get; set; }

		public Guid CourseId { get; set; }
		public Course Course { get; set; }

    }
}
