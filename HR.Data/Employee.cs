using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HR.Data
{
    public class Employee
    {
        [Required]
        public int id { get; set; }

        [Required]
        public string first_name { get; set; }

        [Required]
        public string last_name {get; set;}

        public Employee() 
        { 
        }



    }

}