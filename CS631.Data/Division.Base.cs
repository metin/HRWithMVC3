using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Division : Base
    {
        [Required]
        [DisplayName("Division Code")]
        public int id { get; set; }

        [Required]
        [DisplayName("Division Name")]
        public string name { get; set; }

        public string DivisionNo {
            get {
                return "DV-" + id;
            }
        }


        public Division() 
        { 
        }



    }

}