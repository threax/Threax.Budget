using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Budget.Models 
{
    public partial interface IEntry 
    {
        String Description { get; set; }

        decimal Total { get; set; }

        Guid CategoryId { get; set; }

    }

    public partial interface IEntryId
    {
        Guid EntryId { get; set; }
    }    

    public partial interface IEntryQuery
    {
        Guid? EntryId { get; set; }

    }
}