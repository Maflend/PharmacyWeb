
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacyWeb.Shared.Models
{
    public class Category
    {
        [Key] public int Id { get; set; }
        public Categories Categories { get; set; }
        public virtual List<Product> Products{get;set;}
    }
}
