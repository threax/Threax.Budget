using Budget.Database;
using Budget.InputModels;
using Budget.Repository;
using Budget.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Budget.Tests
{
    public static partial class CategoryTests
    {
        public class Repository : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Repository()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task Add()
            {
                var repo = mockup.Get<ICategoryRepository>();
                var result = await repo.Add(CategoryTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<ICategoryRepository>();
                await repo.AddRange(new CategoryInput[] { CategoryTests.CreateInput(), CategoryTests.CreateInput(), CategoryTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<ICategoryRepository>();
                await repo.AddRange(new CategoryInput[] { CategoryTests.CreateInput(), CategoryTests.CreateInput(), CategoryTests.CreateInput() });
                var result = await repo.Add(CategoryTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Categorys.Count());
                await repo.Delete(result.CategoryId);
                Assert.Equal<int>(3, dbContext.Categorys.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<ICategoryRepository>();
                await repo.AddRange(new CategoryInput[] { CategoryTests.CreateInput(), CategoryTests.CreateInput(), CategoryTests.CreateInput() });
                var result = await repo.Add(CategoryTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Categorys.Count());
                var getResult = await repo.Get(result.CategoryId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasCategorysEmpty()
            {
                var repo = mockup.Get<ICategoryRepository>();
                Assert.False(await repo.HasCategorys());
            }

            [Fact]
            async Task HasCategorys()
            {
                var repo = mockup.Get<ICategoryRepository>();
                await repo.AddRange(new CategoryInput[] { CategoryTests.CreateInput(), CategoryTests.CreateInput(), CategoryTests.CreateInput() });
                Assert.True(await repo.HasCategorys());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<ICategoryRepository>();
                await repo.AddRange(new CategoryInput[] { CategoryTests.CreateInput(), CategoryTests.CreateInput(), CategoryTests.CreateInput() });
                var query = new CategoryQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<ICategoryRepository>();
                var result = await repo.Add(CategoryTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.CategoryId, CategoryTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}