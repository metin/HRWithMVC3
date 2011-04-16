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
        public string first_name { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string last_name {get; set;}

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