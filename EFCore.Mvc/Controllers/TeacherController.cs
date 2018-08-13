using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Data.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Mvc.Controllers
{
    public class TeacherController : Controller
    {
		private readonly SchoolContext _context;

		public TeacherController(SchoolContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
        {
			var teachers = await _context.Teachers.ToListAsync();
            return View(teachers);
        }
    }
}