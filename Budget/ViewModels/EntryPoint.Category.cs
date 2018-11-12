using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Budget.Controllers.Api;

namespace Budget.ViewModels
{
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.List), "ListCategories")]
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Add), "AddCategory")]
    public partial class EntryPoint
    {
        
    }
}