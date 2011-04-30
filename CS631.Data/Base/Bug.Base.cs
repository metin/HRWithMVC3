using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Bug : Base
    {
        public int BugID { get; set; }

        [Required]
        [DisplayName("Project")]
        public int ProjID { get; set; }

        [Required]
        [DisplayName("Assigned To")]
        public int EmpID { get; set; }

        [Required]
        [DisplayName("Details")]
        public string Details { get; set; }

        [Required]
        [DisplayName("Date Reported")]
        public DateTime DateReported { get; set; }

        [DisplayName("Date Closed")]
        public DateTime? DateClosed { get; set; }

        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required]
        [DisplayName("Type")]
        public string Type { get; set; }

        public string ProjectNO {
            get {
                var prj = Project.FindById(this.ProjID);
                return prj.ProjectNO;
            }
        }

        public string Assignee
        {
            get
            {
                var emp = Employee.FindById(this.EmpID);
                return emp.FullName;
            }
        }

        public Bug() 
        { 
        }

    }
}