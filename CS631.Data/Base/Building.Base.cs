using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Building : Base
    {

        public int BuildingID { get; set; }

        [Required]
        [DisplayName("Building Name")]
        public string BuildingName { get; set; }


        [Required]
        [DisplayName("Building Code")]
        public string BuildingCode { get; set; }

        [Required]
        [DisplayName("Year Build")]
        public int YearAcquired { get; set; }

        [Required]
        [DisplayName("Built Cost")]
        public decimal BuildingCost { get; set; }

        
        [DisplayName("Built Cost")]
        public string AcqType { get; set; }

        public Building() 
        { 

        }



    }

}