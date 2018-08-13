using EFCore.Data.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models
{
    public class ClassRoom : ActiveModel
	{

		public Teacher Prefect { get; set; }

	}
}
