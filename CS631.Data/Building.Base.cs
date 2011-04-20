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

        public int Id { get; set; }

        [Required]
        [DisplayName("Building Name")]
        public string Name { get; set; }


        [Required]
        [DisplayName("Building Code")]
        public string Code { get; set; }

        [Required]
        [DisplayName("Year Build")]
        public int Year { get; set; }

        [Required]
        [DisplayName("Built Cost")]
        public decimal Cost { get; set; }

        public Building() 
        { 

        }



    }

}