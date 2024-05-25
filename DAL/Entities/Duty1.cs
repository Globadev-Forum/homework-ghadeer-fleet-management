using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

using Microsoft.EntityFrameworkCore.Metadata.Internal;
using FleetManagement.Models;

namespace FleetManagement.DAL.Entities
{
    public class Duty1
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DutyId { get; set; }

        [Required]
        [DataType(DataType.Date)]

        public DateTime Date { get; set; }
        [Required]
        public string Desc { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required]
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }

        [Required]
        [ForeignKey(nameof(DutyId))]
        public int DriverId { get; set; }

      


    }
}