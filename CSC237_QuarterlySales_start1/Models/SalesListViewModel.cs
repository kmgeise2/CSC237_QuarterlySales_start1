using System.Collections.Generic;

namespace CSC237_QuarterlySales_start1.Models
{
    public class SalesListViewModel
    {
        public List<Sales> Sales { get; set; }
        public List<Employee> Employees { get; set; }
        public int EmployeeId { get; set; }
    }
}
