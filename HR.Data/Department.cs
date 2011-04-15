using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HR.Data
{
    public class Department
    {
        [Required]
        public int id { get; set; }

        [Required]
        [DisplayName("Department Name")]
        public string name { get; set; }


        public Department() 
        { 
        }



    }

}