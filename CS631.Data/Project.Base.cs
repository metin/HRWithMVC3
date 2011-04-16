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
        [Required]
        public int id { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string name { get; set; }

        [Required]
        [DisplayName("Date Started")]
        public DateTime DateStarted { get; set; }

        [Required]
        [DisplayName("Date Ended")]
        public DateTime DateEnded { get; set; }

        [Required]
        [DisplayName("Budget")]
        public decimal Budget { get; set; }

        public string ProjectNO
        {
            get
            {
                return "P-" + id;
            }
        }

        public Project() 
        { 
        }



    }

}