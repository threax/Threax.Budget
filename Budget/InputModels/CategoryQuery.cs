using System;
using Budget.Database;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;

namespace Budget.InputModels
{
    [CacheEndpointDoc]
    public partial class CategoryQuery
    {
        //You can add your own customizations here. These will not be overwritten by the model generator.
        //See CategoryQuery.Generated for the generated code

        /// <summary>
        /// Populate an IQueryable. Does not apply the skip or limit.
        /// </summary>
        /// <param name="query">The query to populate.</param>
        /// <returns>The query passed in populated with additional conditions.</returns>
        public Task<IQueryable<CategoryEntity>> Create(IQueryable<CategoryEntity> query)
        {
            if(CreateGenerated(ref query))
            {
                query = query.OrderByDescending(i => i.Created);
            }

            return Task.FromResult(query);
        }
    }
}