using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Airbnb.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public String RoleName { get; set; }
    }
}
