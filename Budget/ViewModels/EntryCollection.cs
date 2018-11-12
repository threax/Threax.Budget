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
    [HalModel]
    [HalSelfActionLink(typeof(EntrysController), nameof(EntrysController.List))]
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(EntrysController), nameof(EntrysController.Add))]
    [DeclareHalLink(typeof(EntrysController), nameof(EntrysController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntrysController), nameof(EntrysController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntrysController), nameof(EntrysController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntrysController), nameof(EntrysController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class EntryCollection
    {
        public EntryCollection(EntryQuery query, int total, IEnumerable<Entry> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See EntryCollection.Generated for the generated code
    }
}