using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Budget.Models;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Budget.InputModels 
{
    [HalModel]
    public partial class CategoryInput : ICategory
    {
        [Required(ErrorMessage = "Name must have a value.")]
        [MaxLength(1000, ErrorMessage = "Name must be less than 1000 characters.")]
        public String Name { get; set; }

        public decimal Total { get; set; }

    }
}
