using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly IOptions<WebApplication1Options> _options;

        public DepartmentController(IDepartmentService departmentService,IOptions<WebApplication1Options> options)
        {
            _departmentService = departmentService;
            _options = options;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Title = "Department Index";
            var department = await _departmentService.GetAll();
            return View(department);
        }

        public IActionResult Add()
        {
            ViewBag.Title = "Add Department";
            return View(new Department());
        }

        [HttpPost]
        public async Task<IActionResult> Add(Department department)
        {
            if (ModelState.IsValid)
            {
                await _departmentService.Add(department);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}