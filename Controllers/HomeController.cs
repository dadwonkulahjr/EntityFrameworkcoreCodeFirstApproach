using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EntityFrameworkcoreCodeFirstApproach.Models;
using EntityFrameworkcoreCodeFirstApproach.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EntityFrameworkcoreCodeFirstApproach.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepositoryPattern _employeeRepositoryPattern;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IEmployeeRepositoryPattern employeeRepositoryPattern,
            IHostingEnvironment hostingEnvironment,
            ILogger<HomeController> logger)
        {
            this._employeeRepositoryPattern = employeeRepositoryPattern;
            this._hostingEnvironment = hostingEnvironment;
            this._logger = logger;
        }
        [AllowAnonymous]
        public ViewResult Index()
        {
            var listOfEmp = _employeeRepositoryPattern.GetListOfEmployees();
            return View(listOfEmp);
        }
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
           
            Employee employee = _employeeRepositoryPattern.GetEmployee(id.Value);
            if(employee == null)
            {
                Response.StatusCode = 404;
                _logger.LogError($"The employee with Id = {id.Value} cannot be found.");
                return View("EmployeeNotFound", id.Value);
            }
            HomeDetailViewModel homeDetailViewModel = new HomeDetailViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Information!"
            };
            return View(homeDetailViewModel);
        }
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model);

                Employee employee = new Employee()
                {
                    Fullname = model.Fullname,
                    Email = model.Email,
                    Salary = model.Salary,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepositoryPattern.AddEmployee(employee);
                return RedirectToAction("details", new { id = employee.Id });
            }
            return View();
        }
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepositoryPattern.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Fullname = employee.Fullname,
                Email = employee.Email,
                Department = employee.Department,
                Salary = employee.Salary,
                ExistingPhothPath = employee.PhotoPath

            };
          
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                Employee employee = _employeeRepositoryPattern.GetEmployee(model.Id);
                employee.Fullname = model.Fullname;
                employee.Email = model.Email;
                employee.Department = model.Department;
                employee.Salary = model.Salary;
                if (model.Photos != null)
                {
                    if (model.ExistingPhothPath != null)
                    {
                        string filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhothPath);
                        System.IO.File.Delete(filePath);
                    }
                    employee.PhotoPath = ProcessUploadedFile(model);
                }
                _employeeRepositoryPattern.UpdateEmployeeInfo(employee);
                return RedirectToAction("index");
            }
            return View();
        }

        private string ProcessUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photos != null && model.Photos.Count > 0)
            {
                foreach (IFormFile photo in model.Photos)
                {
                    string uploadedFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + " _ " + photo.FileName;
                    string filePath = Path.Combine(uploadedFolder, uniqueFileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        photo.CopyTo(fileStream);
                    }
                }


            }

            return uniqueFileName;
        }

       
    }
}
