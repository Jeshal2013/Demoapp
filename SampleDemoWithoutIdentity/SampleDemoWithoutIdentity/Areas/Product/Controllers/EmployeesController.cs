using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using SampleDemoWithoutIdentity.Data;
using Microsoft.AspNetCore.Identity.UI.Services;
using DataAccess.Services;
using Microsoft.AspNetCore.Authorization;

namespace SampleDemoWithoutIdentity.Areas.Product.Controllers
{
    [Area("Product")]
    
    public class EmployeesController : Controller
    {
        IConfiguration configuration;
        IEmployeeInterface employeeService;
        public EmployeesController(IConfiguration configuration, IEmployeeInterface employeeInterface)
        
        {
            configuration = configuration;
            employeeService = employeeInterface;
        }

        // GET: Product/Employees
        public async Task<IActionResult> Index(string search="",int page=1,string sortby="Name",string orderBy="asc")
        
        {
            //DataAccess.Repository.EmployeeService employeeService = new DataAccess.Repository.EmployeeService();
            //var connectionString = configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection");
            //employeeService.ConnectionString = "";
            var employeeViewModel = employeeService.GetEmployees(search,page,sortByColumn:sortby,orderBy:orderBy);
            employeeViewModel.search = search;
            employeeViewModel.page = page;
            employeeViewModel.pageSize = 20;
            employeeViewModel.sortBy = sortby;
            employeeViewModel.orderBy=(orderBy=="asc"?"desc":"asc");
            return View(employeeViewModel);
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
                //DataAccess.Repository.EmployeeService employeeService = new DataAccess.Repository.EmployeeService();
                //var connectionString = configuration.GetConnectionString("SampleDemoWithoutIdentityContextConnection");
                //employeeService.ConnectionString = connectionString;
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
