using EFCore.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class Student : ActiveModel
    {
		public int Age { get; set; }
		public Guid ClassId { get; set; }
		public ClassRoom Class { get; set; }

		public ICollection<CourseStudent> CourseStudents { get; set; }
	}
}
