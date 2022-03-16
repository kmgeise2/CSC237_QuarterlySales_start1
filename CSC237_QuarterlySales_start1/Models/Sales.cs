using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CSC237_QuarterlySales_start1.Models
{
    public class Sales
    {
        public int SalesId { get; set; }

        [Required(ErrorMessage = "Please enter a quarter.")]
        [Range(1, 4, ErrorMessage = "Quarter must be between 1 and 4.")]
        public int? Quarter { get; set; }

        // Add attributes
        public int? Year { get; set; }

        // Add attributes
        public double? Amount { get; set; }

        // Add attributes
        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}
