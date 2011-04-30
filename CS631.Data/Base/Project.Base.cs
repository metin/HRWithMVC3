using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Project : Base
    {
        public int ProjID { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string ProjName { get; set; }

        [Required]
        [DisplayName("Date Started")]
        public DateTime StartDate { get; set; }

        [DisplayName("Date Ended")]
        public DateTime? EndDate { get; set; }

        [Required]
        [DisplayName("Budget")]
        public decimal ProjBudget { get; set; }

        [Required]
        [DisplayName("Department")]
        public int ProjDept { get; set; }

        [Required]
        [DisplayName("Manager")]
        public int ProjManager { get; set; }  

        public string ProjectNO
        {
            get
            {
                return "P-" + ProjID;
            }
        }

        public Project() 
        { 
        }



    }

}