using EFCore.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore.Mvc.Initializer
{
    public static class ContextInitializer
    {
        private static object _lock = new object();
		private static bool _initialized = false;

		internal static void Initialize(SchoolContext context)
		{
			if (!_initialized)
			{
				lock (_lock)
				{
					if (_initialized == true)
						return;

					_initialized = true;

					InitializeDatabase(context);

				}
			}
		}

		private static void InitializeDatabase(SchoolContext context)
		{
			context.Database.Migrate();

			if (!context.ClassRooms.Any())
				context.ClassRooms.Add(new Data.Models.ClassRoom() { Id = Guid.NewGuid(), Name = "Demo", Prefect = new Data.Models.Teacher() { Name = "DemoPrefect" } });

			context.SaveChanges();
		}
	}
}
