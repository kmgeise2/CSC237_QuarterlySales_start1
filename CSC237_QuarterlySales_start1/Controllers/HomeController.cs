using CSC237_QuarterlySales_start1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CSC237_QuarterlySales_start1.Controllers
{
    public class HomeController : Controller
    {
        private SalesContext context { get; set; }
        public HomeController(SalesContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index(int id)
        {
            // build sales query based on whether there's an employee id to filter by
            IQueryable<Sales> query = context.Sales
                .Include(s => s.Employee)
                .OrderBy(s => s.Year);
            if (id > 0)
                query = query.Where(s => s.EmployeeId == id);

            var vm = new SalesListViewModel
            {
                Sales = query.ToList(),  // execute sales query
                Employees = context.Employees.OrderBy(e => e.Firstname).ToList(),
                EmployeeId = id
            };
            return View(vm);
        }

        [HttpPost]
        public RedirectToActionResult Index(Employee employee)
        {
            if (employee.EmployeeId > 0)
                return RedirectToAction("Index", new { id = employee.EmployeeId });
            else
                // pass empty string for id segment to clear any previous values
                return RedirectToAction("Index", new { id = "" });
        }

    }
}
