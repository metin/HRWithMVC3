using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Employee : Base
    {
        [Required]
        public int id { get; set; }

        [Required]
        [DisplayName("First Name")]
        public string EmpFName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string EmpLName {get; set;}

        [DisplayName("MI")]
        public string EmpMI {get; set;}

        [Required]
        [DisplayName("Title")]
        public string EmpTitle {get; set;}

        [DisplayName("Building")]
        public int EmpBuilding { get; set; }

        [DisplayName("Office")]
        public int EmpOffice { get; set; }

        [DisplayName("Phone")]
        public int EmpPhone { get; set; }

        [DisplayName("Department")]
        public int EmpDept { get; set; }
 
        [DisplayName("Division")]
        public int EmpDiv { get; set; }

        [DisplayName("Project")]
        public int EmpProj { get; set; }

        [Required(AllowEmptyStrings=false)]
        [DisplayName("Employment Type")]
        public string EmpType { get; set; }

        [DisplayName("Hourly Rate")]
        public decimal HourRate { get; set; }

        [DisplayName("Month Hours")]
        public decimal MonthHours { get; set; }

        public string EmployeeNO
        {
            get {
                return "EMP-" + id;
            }
        }

        public Employee() 
        { 
        }



    }

}