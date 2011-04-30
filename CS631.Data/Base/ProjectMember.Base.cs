using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class ProjectMember : Base
    {
        public int EmpProj { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int EmpID { get; set; }

        [Required]
        [DisplayName("Project")]
        public int ProjID { get; set; }

        [Required]
        [DisplayName("Role")]
        public string Role { get; set; }

        [Required]
        [DisplayName("Total Hours")]
        public decimal TotalHours { get; set; }

        [Required]
        [DisplayName("Since")]
        public DateTime StartDate { get; set; }

        public string EmpName {
            get {
                return this.EmployeeObj().EmpFName;
            }
        }

        public string ProjectNO
        {
            get
            {
                return this.ProjectObj().ProjectNO;
            }
        }

        public ProjectMember() 
        { 

        }

    }

}