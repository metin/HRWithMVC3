using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class EmployeeSalary : Base
    {

        [Required]
        [DisplayName("Employee")]
        public int EmpID { get; set; }


        [Required]
        [DisplayName("Salary")]
        public decimal AnnualSalary { get; set; }


        [Required]
        [DisplayName("Date")]
        public DateTime SalaryStartDate { get; set; }

        public EmployeeSalary() 
        { 

        }



    }

}