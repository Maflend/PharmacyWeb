
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PharmacyWeb.Shared.Models
{
    public class User
    {
        [Key] public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        [Required] public Roles Role { get; set; }
        public List<Order> Orders { get; set; }
    }
   
}
