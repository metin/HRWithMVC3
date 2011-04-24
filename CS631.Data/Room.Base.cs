using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CS631.Data
{
    public partial class Room : Base
    {

        public int Id { get; set; }

        [Required]
        [DisplayName("Building")]
        public int BuildingId { get; set; }

        [Required]
        [DisplayName("Room Code")]
        public string Code { get; set; }

        public Room() 
        { 

        }

    }

}