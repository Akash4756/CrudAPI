using CrudAPI.DBAccess;
using CrudAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmployeeController : ControllerBase
    {
        EmployeeDbAccess employeeDb = new EmployeeDbAccess();
        
        ApiResponse response = new ApiResponse();


        [Route("GetEmployees")]
        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var emps =employeeDb.GetEmployees();
                response.Ok = true;
                response.Message = $"Total {emps.Count} Record Save Successfully.";
                response.Data = emps;
            }
            catch(Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
            }
            return Ok(response);
        }
        [Route("PostEmployee")]
        [HttpPost]
        public IActionResult PostEmployee(Employee data)
        {
            try
            {
                var res =employeeDb.CreateEmployee(data);
                if (res == "Ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee Created Successfully.";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Employee Already Exist.";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }

            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                
            }
            return Ok(response);
        }
        [Route("DeleteEmployee")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var res =employeeDb.DeleteEmployee(id);
                if (res == "Ok")
                {
                    response.Ok =true;
                    response.Message = $"Employee Deleted Successfully.";
                }
                else if (res == "fail")
                {
                    response.Ok = false;
                    response.Message = $"Something Went Wrong";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }

            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                
            }
            return Ok(response);
        }
        [Route("UpdateEmployee")]
        [HttpPut]
        public IActionResult UpdateEmployee(Employee emp)
        {
            try
            {
                var res = employeeDb.UpdateEmployee(emp);
                if (res == "Ok")
                {
                    response.Ok = true;
                    response.Message = $"Employee Updated Successfully.";
                }
                else
                {
                    response.Ok = false;
                    response.Message = res;
                }
            }
            catch (Exception ex)
            {
                response.Ok = false;
                response.Message = ex.Message;
                
            }
            return Ok(response);
        }
    }
}
