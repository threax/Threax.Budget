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
    [HalSelfActionLink(typeof(CategorysController), nameof(CategorysController.Get))]
    [HalActionLink(typeof(CategorysController), nameof(CategorysController.Update))]
    [HalActionLink(typeof(CategorysController), nameof(CategorysController.Delete))]
    public partial class Category
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Category.Generated for the generated code
    }
}