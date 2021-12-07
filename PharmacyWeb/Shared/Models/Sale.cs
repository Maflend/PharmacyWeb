using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared.Models
{
    public class Sale
    {
        [Key]public int Id { get; set; }
        [Required]public Order Order { get; set; }
        [Required]public Product Product { get; set; }
        [Required] public int Quantity { get; set; }
    }
}
