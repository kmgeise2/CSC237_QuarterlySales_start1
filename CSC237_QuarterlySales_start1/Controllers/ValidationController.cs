using CSC237_QuarterlySales_start1.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CSC237_QuarterlySales_start1.Controllers
{
    public class ValidationController : Controller
    {
        // Constructor accepts a SalesContext object and stores in private context property
        private SalesContext context { get; set; } // Define property
        public ValidationController(SalesContext ctx) => context = ctx;

        // An action method for the Remote attribute must have a return type of JsonResult
        // See Employee and Sales classes for client remote call to server method
        public JsonResult CheckEmployee(DateTime dob, string firstname, string lastname)
        {
            var employee = new Employee
            {
                Firstname = firstname,
                Lastname = lastname,
                DOB = dob
            };
            //
            // Calls the CheckEmployee static method in the Validate model
            //
            string msg = Validate.CheckEmployee(context, employee);
            if (string.IsNullOrEmpty(msg))
                return Json(true);
            else
                return Json(msg); // Error message returned here (duplicate employee)
        }

        // An action method for the Remote attribute must have a return type of JsonResult
        public JsonResult CheckManager(int managerId, string firstname, string lastname, DateTime dob)
        {
            var employee = new Employee
            {
                Firstname = firstname,
                Lastname = lastname,
                DOB = dob,
                ManagerId = managerId
            };
            //
            // Calls the CheckManager static method in the Validate model
            //
            string msg = Validate.CheckManagerEmployeeMatch(context, employee);
            if (string.IsNullOrEmpty(msg))
                return Json(true);
            else
                return Json(msg); // Error message returned here 
        }
        // An action method for the Remote attribute must have a return type of JsonResult
        public JsonResult CheckSales(int quarter, int year, int employeeId)
        {
            var sales = new Sales
            {
                Quarter = quarter,
                Year = year,
                EmployeeId = employeeId
            };
            //
            // Calls the CheckSales static method in the Validate model
            //
            string msg = Validate.CheckSales(context, sales);
            if (string.IsNullOrEmpty(msg))
                return Json(true);
            else
                return Json(msg); //Duplicate sales data message
        }

    }
}