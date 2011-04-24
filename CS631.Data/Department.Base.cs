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

        [DisplayName("Department Head")]
        public int? DeptHead { get; set; }

        [Required]
        [DisplayName("Division")]
        public int DivId { get; set; }
        

        public String DepartmentHead
        {
            get
            {
                var e = Employee.FindById(this.DeptHead.GetValueOrDefault());
                return e.FullName;
            }
        }

        public String DivisionName
        {
            get
            {
                var d = Division.FindByID(this.DivId);
                return d.DivisionNo;
            }
        }

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