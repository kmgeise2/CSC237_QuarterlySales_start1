using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CSC237_QuarterlySales_start1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string Firstname { get; set; }

        // Add attributes here
        public string Lastname { get; set; }

       // Add attributes here
        public DateTime? DOB { get; set; }

        // Add attributes here
        public DateTime? DateOfHire { get; set; }

        // Add attributes here
        public int ManagerId { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";
    }
}
