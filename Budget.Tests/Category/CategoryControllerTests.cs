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
    public static partial class CategoryTests
    {
        public class Controller : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Controller()
            {
                mockup.Add<CategoriesController>(m => new CategoriesController(m.Get<ICategoryRepository>())
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

                var controller = mockup.Get<CategoriesController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(CategoryTests.CreateInput()));
                }

                var query = new CategoryQuery();
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

                var controller = mockup.Get<CategoriesController>();

                for (var i = 0; i < totalItems; ++i)
                {
                    Assert.NotNull(await controller.Add(CategoryTests.CreateInput()));
                }

                //Manually add the item we will look back up
                var lookup = await controller.Add(CategoryTests.CreateInput());
                var result = await controller.Get(lookup.CategoryId);
                Assert.NotNull(result);
            }

            [Fact]
            async Task Add()
            {
                var controller = mockup.Get<CategoriesController>();

                var result = await controller.Add(CategoryTests.CreateInput());
                Assert.NotNull(result);
            }

            [Fact]
            async Task Update()
            {
                var controller = mockup.Get<CategoriesController>();

                var result = await controller.Add(CategoryTests.CreateInput());
                Assert.NotNull(result);

                var updateResult = await controller.Update(result.CategoryId, CategoryTests.CreateInput());
                Assert.NotNull(updateResult);
            }

            [Fact]
            async Task Delete()
            {
                var controller = mockup.Get<CategoriesController>();

                var result = await controller.Add(CategoryTests.CreateInput());
                Assert.NotNull(result);

                var listResult = await controller.List(new CategoryQuery());
                Assert.Equal(1, listResult.Total);

                await controller.Delete(result.CategoryId);

                listResult = await controller.List(new CategoryQuery());
                Assert.Equal(0, listResult.Total);
            }
        }
    }
}