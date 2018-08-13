using EFCore.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCore.Data.Models
{
	public enum Department
	{
		Science,
		Math,
		Art
	}

    public class Course : ActiveModel
    {
		public Department Department { get; set; }

		public ICollection<CourseStudent> CourseStudents { get; set; }
	}
}
