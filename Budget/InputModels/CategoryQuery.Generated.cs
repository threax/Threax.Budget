using Halcyon.HAL.Attributes;
using Budget.Controllers;
using Budget.Models;
using Budget.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;
using Threax.AspNetCore.Models;
using System.ComponentModel.DataAnnotations;

namespace Budget.InputModels
{
    [HalModel]
    public partial class CategoryQuery : PagedCollectionQuery, ICategoryQuery
    {
        /// <summary>
        /// Lookup a category by id.
        /// </summary>
        public Guid? CategoryId { get; set; }


        /// <summary>
        /// Populate an IQueryable for categories. Does not apply the skip or limit. Will return
        /// true if the query should be modified or false if the entire query was built and should
        /// be left alone.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>True if the query should continue to be built, false if it should be left alone.</returns>
        protected bool CreateGenerated(ref IQueryable<CategoryEntity> query)
        {
            if (CategoryId != null)
            {
                query = query.Where(i => i.CategoryId == CategoryId);
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}