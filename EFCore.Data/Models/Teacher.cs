using EFCore.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class Teacher : ActiveModel
	{
		public Guid ClassId { get; set; }
		public ClassRoom Class { get; set; }
		public string PublicName { get; set; }

	}
}
