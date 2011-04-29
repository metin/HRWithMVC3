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
        public int DivID { get; set; }

        [Required]
        [DisplayName("Division Name")]
        public string DivName { get; set; }

        [DisplayName("Division Head")]
        public int? DivHead { get; set; }
        

        public string DivisionNo {
            get {
                return "DV-" + DivID;
            }
        }

        public String DivisionHead
        {
            get {
                var e = Employee.FindById(this.DivHead.GetValueOrDefault());
                return e.FullName;
            }
        }

        public Division() 
        { 
        }



    }

}