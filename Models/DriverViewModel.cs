using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Web;


namespace FleetManagement.Models
{
    public class DriverViewModel
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DriverId { get; set; }

        [Required(ErrorMessage = "Driver name is required")]
        [DisplayName("Driver Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mobile No. is required")]
        [DataType(DataType.PhoneNumber)]
        [DisplayName("Mobile No.")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Email address is required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public virtual ICollection <DutyViewModel> Duties { get; set; }
        public virtual ICollection <VehicleViewModel> Vehicles  { get; set; }




    }
}