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
    public static partial class EntryTests
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
                var repo = mockup.Get<IEntryRepository>();
                var result = await repo.Add(EntryTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task AddRange()
            {
                var repo = mockup.Get<IEntryRepository>();
                await repo.AddRange(new EntryInput[] { EntryTests.CreateInput(), EntryTests.CreateInput(), EntryTests.CreateInput() });
            }

            [Fact]
            async Task Delete()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IEntryRepository>();
                await repo.AddRange(new EntryInput[] { EntryTests.CreateInput(), EntryTests.CreateInput(), EntryTests.CreateInput() });
                var result = await repo.Add(EntryTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Entrys.Count());
                await repo.Delete(result.EntryId);
                Assert.Equal<int>(3, dbContext.Entrys.Count());
            }

            [Fact]
            async Task Get()
            {
                var dbContext = mockup.Get<AppDbContext>();
                var repo = mockup.Get<IEntryRepository>();
                await repo.AddRange(new EntryInput[] { EntryTests.CreateInput(), EntryTests.CreateInput(), EntryTests.CreateInput() });
                var result = await repo.Add(EntryTests.CreateInput());
                Assert.Equal<int>(4, dbContext.Entrys.Count());
                var getResult = await repo.Get(result.EntryId);
                Assert.NotNull(getResult);
            }

            [Fact]
            async Task HasEntrysEmpty()
            {
                var repo = mockup.Get<IEntryRepository>();
                Assert.False(await repo.HasEntrys());
            }

            [Fact]
            async Task HasEntrys()
            {
                var repo = mockup.Get<IEntryRepository>();
                await repo.AddRange(new EntryInput[] { EntryTests.CreateInput(), EntryTests.CreateInput(), EntryTests.CreateInput() });
                Assert.True(await repo.HasEntrys());
            }

            [Fact]
            async Task List()
            {
                //This could be more complete
                var repo = mockup.Get<IEntryRepository>();
                await repo.AddRange(new EntryInput[] { EntryTests.CreateInput(), EntryTests.CreateInput(), EntryTests.CreateInput() });
                var query = new EntryQuery();
                var result = await repo.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Update()
            {
                var repo = mockup.Get<IEntryRepository>();
                var result = await repo.Add(EntryTests.CreateInput());
                Assert.NotNull(result);
                var updateResult = await repo.Update(result.EntryId, EntryTests.CreateInput());
                Assert.NotNull(updateResult);
            }
        }
    }
}