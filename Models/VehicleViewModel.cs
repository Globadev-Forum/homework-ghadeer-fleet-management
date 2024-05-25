using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
using System.Web.Services.Description;


namespace FleetManagement.Models
{
    public class VehicleViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VehicleId { get; set; }

        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Vehicle_Desc { get; set; }

        [DisplayName("Plate Number")]
        [Required(ErrorMessage = "Plate number is required")]
        public string Vehicle_Plate_No { get; set; }

        [DisplayName("Registation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Registration date is required")]
        public DateTime? Vehicle_Reg_Date { get; set; }

        [DisplayName("Registation Expiry Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Registration expiry date is required")]
        public DateTime? Vehicle_Exp_Reg_Date { get; set; }
        
        [DisplayName("Insurance Policy Number")]
        [Required(ErrorMessage = "Insurance policy number is required")]
        public string Vehicle_Ins_PolicyNo { get; set; }

        [Required]
        [DisplayName("Driver")]
        public int DriverId { get; set; }

        [ForeignKey("DriverId")]
        public virtual DriverViewModel V_VehicleDriversVM { get; set; }

        public byte[] Image { get; set; }
    }
}