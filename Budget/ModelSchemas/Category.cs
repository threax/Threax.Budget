using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Budget.ModelSchemas
{
    [PluralName("Categories")]
    public class Category
    {
        [Required(ErrorMessage = "You must include a name.")]
        [MaxLength(1000, ErrorMessage = "The category name must be less than 1000 characters.")]
        public String Name { get; set; }

        public decimal Total { get; set; }
    }
}
