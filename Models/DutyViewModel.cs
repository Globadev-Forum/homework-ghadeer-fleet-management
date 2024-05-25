using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using System.Web.Services.Description;
using System.Globalization;



namespace FleetManagement.Models
{
    public class DutyViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DutyId { get; set; }


        [DisplayName("Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Desc { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime? Date { get; set; }


        [DisplayName("Start Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Start time is required")]
        public DateTime? StartTime { get; set; }


        [DisplayName("End Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "End time is required")]
        public DateTime? EndTime { get; set; }

        [Required]
        [DisplayName("Driver")]
        public int DriverId { get; set; }

        
        [ForeignKey("DriverId")]
        public virtual DriverViewModel V_DriversVM { get; set; }



    }


}