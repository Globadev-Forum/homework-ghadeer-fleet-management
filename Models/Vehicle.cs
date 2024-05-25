using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FleetManagement.Models
{
    public class Vehicle
    {
        
        public int id { get; set; }

        [DisplayName("Description")]
        public string Desc  { get; set; }

        [DisplayName("Plate Number")]
        public string Plate_No { get; set; }

        [DisplayName("Registration Date")]
        public DateTime Reg_Date { get; set;}

        [DisplayName("Registration Expiry Date")]
        public DateTime Reg_Exp_Date { get; set; }

        [DisplayName("Insurance Expiry Date")]
        public DateTime Insurance_Exp_Date { get; set; }

        [DisplayName("Insurance Policy Number")]
        public string Insurance_PolicyNo { get; set; }
      


    }
}