using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Budget.Database
{
    public partial class EntryEntity
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See EntryEntity.Generated for the generated code
        public CategoryEntity Category { get; set; }
    }
}