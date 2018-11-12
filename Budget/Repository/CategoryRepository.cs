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
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Budget.Repository
{
    public partial class CategoryRepository : ICategoryRepository
    {
        private AppDbContext dbContext;
        private AppMapper mapper;

        public CategoryRepository(AppDbContext dbContext, AppMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<CategoryCollection> List(CategoryQuery query)
        {
            var dbQuery = await query.Create(this.Entities);

            var total = await dbQuery.CountAsync();
            dbQuery = dbQuery.Skip(query.SkipTo(total)).Take(query.Limit);
            var results = await dbQuery.ToListAsync();

            return new CategoryCollection(query, total, results.Select(i => mapper.MapCategory(i, new Category())));
        }

        public async Task<Category> Get(Guid categoryId)
        {
            var entity = await this.Entity(categoryId);
            return mapper.MapCategory(entity, new Category());
        }

        public async Task<Category> Add(CategoryInput category)
        {
            var entity = mapper.MapCategory(category, new CategoryEntity());
            this.dbContext.Add(entity);
            await SaveChanges();
            return mapper.MapCategory(entity, new Category());
        }

        public async Task<Category> Update(Guid categoryId, CategoryInput category)
        {
            var entity = await this.Entity(categoryId);
            if (entity != null)
            {
                mapper.MapCategory(category, entity);
                await SaveChanges();
                return mapper.MapCategory(entity, new Category());
            }
            throw new KeyNotFoundException($"Cannot find category {categoryId.ToString()}");
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

        public virtual async Task<bool> HasCategories()
        {
            return await Entities.CountAsync() > 0;
        }

        public virtual async Task AddRange(IEnumerable<CategoryInput> categories)
        {
            var entities = categories.Select(i => mapper.MapCategory(i, new CategoryEntity()));
            this.dbContext.Categories.AddRange(entities);
            await SaveChanges();
        }


        public async Task<IEnumerable<ILabelValuePair>> GetLabels()
        {
            return await dbContext.Categories.Select(i => new LabelValuePair<Guid>(i.Name, i.CategoryId)).ToListAsync();
        }
        protected virtual async Task SaveChanges()
        {
            await this.dbContext.SaveChangesAsync();
        }

        private DbSet<CategoryEntity> Entities
        {
            get
            {
                return dbContext.Categories;
            }
        }

        private Task<CategoryEntity> Entity(Guid categoryId)
        {
            return Entities.Where(i => i.CategoryId == categoryId).FirstOrDefaultAsync();
        }
    }
}