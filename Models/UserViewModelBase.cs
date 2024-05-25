using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FleetManagement.Models
{
    public class UserViewModelBase
    {

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }
    }
}