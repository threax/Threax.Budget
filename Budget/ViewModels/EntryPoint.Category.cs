using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Budget.Controllers.Api;

namespace Budget.ViewModels
{
    [HalActionLink(typeof(CategorysController), nameof(CategorysController.List), "ListCategorys")]
    [HalActionLink(typeof(CategorysController), nameof(CategorysController.Add), "AddCategory")]
    public partial class EntryPoint
    {
        
    }
}