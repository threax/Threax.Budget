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
    public partial interface ICategory 
    {
        String Name { get; set; }

    }

    public partial interface ICategoryId
    {
        Guid CategoryId { get; set; }
    }    

    public partial interface ICategoryQuery
    {
        Guid? CategoryId { get; set; }

    }
}