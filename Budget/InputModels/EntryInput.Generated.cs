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
        public String Description { get; set; }

        public decimal Total { get; set; }

    }
}
