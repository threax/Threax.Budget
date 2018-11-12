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
    [HalSelfActionLink(typeof(CategoriesController), nameof(CategoriesController.Get))]
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Update))]
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Delete))]
    public partial class Category
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See Category.Generated for the generated code
    }
}