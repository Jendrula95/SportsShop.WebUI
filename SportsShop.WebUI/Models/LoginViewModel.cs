using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SportsShop.WebUI.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Login")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Hasło")]
        public string Password { get; set; }
    }
}