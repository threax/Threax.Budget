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
    [HalSelfActionLink(typeof(EntriesController), nameof(EntriesController.List))]
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(EntriesController), nameof(EntriesController.Add))]
    [DeclareHalLink(typeof(EntriesController), nameof(EntriesController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntriesController), nameof(EntriesController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntriesController), nameof(EntriesController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(EntriesController), nameof(EntriesController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class EntryCollection
    {
        public EntryCollection(decimal amountTotal, EntryQuery query, int total, IEnumerable<Entry> items) : base(query, total, items)
        {
            this.AmountTotal = amountTotal;
        }

        public decimal AmountTotal { get; private set; }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See EntryCollection.Generated for the generated code
    }
}