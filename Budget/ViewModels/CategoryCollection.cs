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
    [HalSelfActionLink(typeof(CategoriesController), nameof(CategoriesController.List))]
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Get), DocsOnly = true)] //This provides access to docs for showing items
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.List), DocsOnly = true)] //This provides docs for searching the list
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Update), DocsOnly = true)] //This provides access to docs for updating items if the ui has different modes
    [HalActionLink(typeof(CategoriesController), nameof(CategoriesController.Add))]
    [DeclareHalLink(typeof(CategoriesController), nameof(CategoriesController.List), PagedCollectionView<Object>.Rels.Next, ResponseOnly = true)]
    [DeclareHalLink(typeof(CategoriesController), nameof(CategoriesController.List), PagedCollectionView<Object>.Rels.Previous, ResponseOnly = true)]
    [DeclareHalLink(typeof(CategoriesController), nameof(CategoriesController.List), PagedCollectionView<Object>.Rels.First, ResponseOnly = true)]
    [DeclareHalLink(typeof(CategoriesController), nameof(CategoriesController.List), PagedCollectionView<Object>.Rels.Last, ResponseOnly = true)]
    public partial class CategoryCollection
    {
        public CategoryCollection(CategoryQuery query, int total, IEnumerable<Category> items) : base(query, total, items)
        {
            
        }

        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See CategoryCollection.Generated for the generated code
    }
}