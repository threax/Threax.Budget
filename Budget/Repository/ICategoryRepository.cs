using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budget.InputModels;
using Budget.ViewModels;
using Budget.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Budget.Repository
{
    public partial interface ICategoryRepository
    {
        Task<Category> Add(CategoryInput value);
        Task AddRange(IEnumerable<CategoryInput> values);
        Task Delete(Guid id);
        Task<Category> Get(Guid categoryId);
        Task<bool> HasCategorys();
        Task<CategoryCollection> List(CategoryQuery query);
        Task<Category> Update(Guid categoryId, CategoryInput value);
    }
}