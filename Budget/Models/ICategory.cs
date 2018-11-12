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
        //Customize main interface here, see Category.Generated for generated code
    }  

    public partial interface ICategoryId
    {
        //Customize id interface here, see Category.Generated for generated code
    }    

    public partial interface ICategoryQuery
    {
        //Customize query interface here, see Category.Generated for generated code
    }
}