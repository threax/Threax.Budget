using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Budget.Database;
using Budget.InputModels;
using Budget.ViewModels;
using Budget.Models;
using Budget.Mappers;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Halcyon.Ext;

namespace Budget.Repository
{
    public partial class EntryRepository : IEntryRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public EntryRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<EntryCollection> List(EntryQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            var now = DateTime.Now;
            var firstOfMonth = new DateTime(now.Year, now.Month, 1, 0, 0, 0);
            var amountTotal = (await dbQuery.Where(i => i.Created >= firstOfMonth).ToListAsync()).Sum(i => i.Total);
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new EntryCollection(amountTotal, query, total, results.Select(i => mapper.MapEntry(i, new Entry())));
        }

        public async Task<Entry> Get(Guid entryId)
        {
            var entity = await this.Entity(entryId);
            return mapper.MapEntry(entity, new Entry());
        }

        public async Task<Entry> Add(EntryInput entry)
        {
            var entity = mapper.MapEntry(entry, new EntryEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapEntry(entity, new Entry());
        }

        public async Task<Entry> Update(Guid entryId, EntryInput entry)
        {
            var entity = await this.Entity(entryId);
            if (entity != null)
            {
                mapper.MapEntry(entry, entity);
                await SaveChanges();
                return mapper.MapEntry(entity, new Entry());
            }
            throw new KeyNotFoundException($"Cannot find entry {entryId.ToString()}");
        }

        public async Task Delete(Guid id)
        {
            var entity = await this.Entity(id);
            if (entity != null)
            {
                Entities.Remove(entity);
                await SaveChanges();
            }
        }

        public virtual async Task<bool> HasEntries()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<EntryInput> entries)
        {
            var entities = entries.Select(i => mapper.MapEntry(i, new EntryEntity()));
            this.dbContext.Entries.AddRange(entities);
            await SaveChanges();
        }

        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<EntryEntity> Entities
        {
            get
            {
                return dbContext.Entries;
            }
        }

        private Task<EntryEntity> Entity(Guid entryId)
        {
            return Entities.Where(i => i.EntryId == entryId).FirstOrDefaultAsync();
        }
    }
}