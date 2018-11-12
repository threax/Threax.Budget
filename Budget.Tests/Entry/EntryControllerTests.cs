using Budget.Controllers.Api;
using Budget.InputModels;
using Budget.Repository;
using Budget.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Budget.Tests
{
    public static partial class EntryTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<EntrysController>(m => new EntrysController(m.Get<IEntryRepository>())
                {
                    ControllerContext = m.Get<ControllerContext>()
                });
            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            async Task List()
            {
                var totalItems = 3;

                var controller = mockup.Get<EntrysController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(EntryTests.CreateInput()));
                }

                var query = new EntryQuery();
                var result = await controller.List(query);
                Assert.Equal(query.Limit, result.Limit);
                Assert.Equal(query.Offset, result.Offset);
                Assert.Equal(3, result.Total);
                Assert.NotEmpty(result.Items);
            }

            [Fact]
            async Task Get()
            {
                var totalItems = 3;

                var controller = mockup.Get<EntrysController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(EntryTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(EntryTests.CreateInput());
                var result = await controller.Get(lookup.EntryId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<EntrysController>();

                var result = await controller.Add(EntryTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<EntrysController>();

                var result = await controller.Add(EntryTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.EntryId, EntryTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<EntrysController>();

                var result = await controller.Add(EntryTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new EntryQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.EntryId);

                listResult = await controller.List(new EntryQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}