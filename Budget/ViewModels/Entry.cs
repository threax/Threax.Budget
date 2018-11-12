using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Budget.Models;
using Budget.Controllers.Api;

namespace Budget.ViewModels
{
    [HalModel]
    [HalSelfActionLink(typeof(EntriesController), nameof(EntriesController.Get))]
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Update))]
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Delete))]
    public partial class Entry
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Entry.Generated for the generated code
    }
}