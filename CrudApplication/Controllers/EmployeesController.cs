using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplication.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult ShowEmployee()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            return View();
        }
    }
}
