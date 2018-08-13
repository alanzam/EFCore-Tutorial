using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFCore.Data.Models.BaseModels
{
    public abstract class ActiveModel
    {
		public Guid Id { get; set; }
		[Required, MaxLength(75)]
		public string Name { get; set; }
		public bool IsActive { get; set; }

    }
}
