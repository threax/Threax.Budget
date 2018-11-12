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
    public partial class EntriesController : Controller
    {
        private IEntryRepository repo;

        public EntriesController(IEntryRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [HalRel(CrudRels.List)]
        public async Task<EntryCollection> List([FromQuery] EntryQuery query)
        {
            return await repo.List(query);
        }

        [HttpGet("{EntryId}")]
        [HalRel(CrudRels.Get)]
        public async Task<Entry> Get(Guid entryId)
        {
            return await repo.Get(entryId);
        }

        [HttpPost]
        [HalRel(CrudRels.Add)]
        [AutoValidate("Cannot add new entry")]
        public async Task<Entry> Add([FromBody]EntryInput entry)
        {
            return await repo.Add(entry);
        }

        [HttpPut("{EntryId}")]
        [HalRel(CrudRels.Update)]
        [AutoValidate("Cannot update entry")]
        public async Task<Entry> Update(Guid entryId, [FromBody]EntryInput entry)
        {
            return await repo.Update(entryId, entry);
        }

        [HttpDelete("{EntryId}")]
        [HalRel(CrudRels.Delete)]
        public async Task Delete(Guid entryId)
        {
            await repo.Delete(entryId);
        }
    }
}