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
    public partial class EntryInput : IEntry
    {
        [Required(ErrorMessage = "Description must have a value.")]
        [MaxLength(1000, ErrorMessage = "Description must be less than 1000 characters.")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Total must have a value.")]
        public decimal Total { get; set; }

        [Required(ErrorMessage = "Category Id must have a value.")]
        [ValueProvider(typeof(Budget.Services.CategoryValueProvider))]
        public Guid CategoryId { get; set; }

    }
}
