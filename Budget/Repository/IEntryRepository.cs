using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Budget.InputModels;
using Budget.ViewModels;
using Budget.Models;
using Threax.AspNetCore.Halcyon.Ext;

namespace Budget.Repository
{
    public partial interface IEntryRepository
    {
        Task<Entry> Add(EntryInput value);
        Task AddRange(IEnumerable<EntryInput> values);
        Task Delete(Guid id);
        Task<Entry> Get(Guid entryId);
        Task<bool> HasEntrys();
        Task<EntryCollection> List(EntryQuery query);
        Task<Entry> Update(Guid entryId, EntryInput value);
    }
}