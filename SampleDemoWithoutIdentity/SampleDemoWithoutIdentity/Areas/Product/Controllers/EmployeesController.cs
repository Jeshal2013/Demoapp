using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using SampleDemoWithoutIdentity.Data;

namespace SampleDemoWithoutIdentity.Areas.Product.Controllers
{
    [Area("Product")]
    public class EmployeesController : Controller
    {
        IConfiguration configuration;
        public EmployeesController(IConfiguration configuration)
        {
            configuration = configuration;
        }

        // GET: Product/Employees
        public async Task<IActionResult> Index()
        {
            DataAccess.Repository.EmployeeService employeeService = new DataAccess.Repository.EmployeeService();
            var connectionString = configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection");
            employeeService.ConnectionString = "";
            var employees = employeeService.GetEmployees();
            return View(employees);
        }

       
        // GET: Product/Employees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create(DataAccess.Models.Employee  employee)
        {
            if (ModelState.IsValid)
            {
                DataAccess.Repository.EmployeeService employeeService = new DataAccess.Repository.EmployeeService();
                var connectionString = configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection");
                employeeService.ConnectionString = connectionString;
                var returnValue= employeeService.InsertEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        // GET: Product/Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
          
            return View();
        }

        // POST: Product/Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,PhoneNumber,City")] Employee employee)
        {
          
            return View();
        }

        // GET: Product/Employees/Delete/5
      
    }
}
