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
        //Customize main interface here, see Entry.Generated for generated code
    }  

    public partial interface IEntryId
    {
        //Customize id interface here, see Entry.Generated for generated code
    }    

    public partial interface IEntryQuery
    {
        //Customize query interface here, see Entry.Generated for generated code
    }
}