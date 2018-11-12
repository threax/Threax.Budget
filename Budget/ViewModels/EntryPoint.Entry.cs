using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Budget.Controllers.Api;

namespace Budget.ViewModels
{
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.List), "ListEntrys")]
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.Add), "AddEntry")]
    public partial class EntryPoint
    {
        
    }
}