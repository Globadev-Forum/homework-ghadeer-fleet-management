using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FleetManagement.DAL.Entities
{
    public class Vehicle
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Desc { get; set; }
        [Required]
        public string Plate_No { get; set; }
        [Required]
        public DateTime Reg_Date { get; set; }
        [Required]
        public DateTime Reg_Exp_Date { get; set;}
        [Required]
        public DateTime Insurance_Exp_Date { get; set;}
        [Required]
        public string Insurance_PolicyNo { get;set; }

       


       
    }
}