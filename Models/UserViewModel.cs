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
    public class UserViewModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("User Name")]
        [Required(ErrorMessage = "User name is required")]
        public string UserName { get; set; }

        [DisplayName("Password") ]
        [DataType (DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public int IsAdmin { get; set; }
    }
}