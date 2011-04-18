using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Department : Base
    {
        [Required]
        public int id { get; set; }

        [Required]
        [DisplayName("Department Name")]
        public string name { get; set; }

        public string DepartmentNo
        {
            get
            {
                return "DP-" + id;
            }
        }

        public Department() 
        { 
        }



    }

}