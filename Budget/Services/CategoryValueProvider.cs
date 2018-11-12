using Budget.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Budget.Services
{
    public class CategoryValueProvider : LabelValuePairProvider
    {
        private ICategoryRepository repo;

        public CategoryValueProvider(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        protected override Task<IEnumerable<ILabelValuePair>> GetSources()
        {
            return repo.GetLabels();
        }
    }
}
