using Halcyon.HAL.Attributes;
using Budget.Controllers.Api;
using Budget.Models;
using Budget.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Budget.ViewModels
{
    public partial class ValueCollection : PagedCollectionViewWithQuery<Value, ValueQuery>
    {
        
    }
}