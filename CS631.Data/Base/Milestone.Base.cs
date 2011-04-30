using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Milestone : Base
    {
        public int MilestoneID { get; set; }

        [Required]
        [DisplayName("Project")]
        public int ProjID { get; set; }

        [Required]
        [DisplayName("Date Started")]
        public DateTime MilestonePlannedDate { get; set; }

        [Required]
        [DisplayName("Description")]
        public string MilestoneDeliverable { get; set; }

        [DisplayName("Date Delivered")]
        public DateTime? MilestoneDeliveryDate { get; set; }

        [Required]
        [DisplayName("Delivered")]
        public string ToBeDelivered { get; set; }


        public Milestone() 
        { 
        }



    }

}