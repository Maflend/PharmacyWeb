
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared.Models
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required] [MaxLength(40)] public string Name { get; set; }
        [MaxLength(150)] public string Description { get; set; }
        [Required]  public int Quantity { get; set; }
        [Required]  public double PurchasingPrice { get; set; }
        [Required]  public double RetailPrice { get; set; }
        public virtual Category Category { get; set; }
        public List<Sale> Sales { get; set; }
    }
}
