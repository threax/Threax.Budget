using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Budget.Controllers.Api;

namespace Budget.ViewModels
{
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.List), "ListEntries")]
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Add), "AddEntry")]
    public partial class EntryPoint
    {
        
    }
}