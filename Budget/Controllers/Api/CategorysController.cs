using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Budget.Repository;
using Threax.AspNetCore.Halcyon.Ext;
using Budget.ViewModels;
using Budget.InputModels;
using Budget.Models;
using Microsoft.AspNetCore.Authorization;

namespace Budget.Controllers.Api
{
    [Route("api/[controller]")]
    [ResponseCache(NoStore = true)]
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Bearer)]
    public partial class CategorysController : Controller
    {
        private ICategoryRepository repo;

        public CategorysController(ICategoryRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<CategoryCollection> List([FromQuery] CategoryQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{CategoryId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Category> Get(Guid categoryId)
        {
            return await repo.Get(categoryId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new category")]
        public async Task<Category> Add([FromBody]CategoryInput category)
        {
            return await repo.Add(category);
        }

        [HttpPut("{CategoryId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update category")]
        public async Task<Category> Update(Guid categoryId, [FromBody]CategoryInput category)
        {
            return await repo.Update(categoryId, category);
        }

        [HttpDelete("{CategoryId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid categoryId)
        {
            await repo.Delete(categoryId);
        }
    }
}