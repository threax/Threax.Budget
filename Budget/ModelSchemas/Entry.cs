using Budget.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Budget.ModelSchemas
{
    [PluralName("Entries")]
    public class Entry
    {
        [Required(ErrorMessage = "You must include a description.")]
        [MaxLength(1000, ErrorMessage = "The description must be less than 1000 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "You must include a total.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "You must include a category.")]
        [DefineValueProvider(typeof(CategoryValueProvider))]
        [Queryable]
        public Guid CategoryId { get; set; }
    }
}
