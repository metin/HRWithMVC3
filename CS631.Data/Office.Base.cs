using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Office : Base
    {

        public int OfficeID { get; set; }

        [Required]
        [DisplayName("Building")]
        public int BuildingID { get; set; }

        [Required]
        [DisplayName("Department")]
        public int DeptID { get; set; }

        [Required]
        [DisplayName("Office Number")]
        public string OfficeNumber { get; set; }

        [DisplayName("Area")]
        public decimal Area { get; set; }

        [DisplayName("Room Type")]
        public string RoomType { get; set; }

        public Office() 
        { 

        }

    }

}