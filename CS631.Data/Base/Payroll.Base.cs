using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Payroll : Base
    {
        public int HistoyID { get; set; }

        [Required]
        [DisplayName("Employee")]
        public int EmpID { get; set; }

        [Required]
        [DisplayName("Date of Payment")]
        public DateTime PayDate { get; set; }

        [Required]
        [DisplayName("Paycheck Amount")]
        public decimal? MonthSalary { get; set; }

        [DisplayName("Hours")]
        public int? MonthHours  { get; set; }

        [Required]
        [DisplayName("Federal Tax")]
        public decimal FedTax { get; set; }

        [Required]
        [DisplayName("State Tax")]
        public decimal StateTax { get; set; }

        [DisplayName("Other Tax")]
        public decimal? OtherTax { get; set; }

        [Required]
        [DisplayName("Net Pay")]
        public decimal NetPay { get; set; }


        public Payroll() 
        { 

        }


    }

}