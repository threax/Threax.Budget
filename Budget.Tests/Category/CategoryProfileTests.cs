using AutoMapper;
using Budget.Database;
using Budget.ViewModels;
using Budget.Mappers;
using Budget.Models;
using System;
using Threax.AspNetCore.Tests;
using Xunit;

namespace Budget.Tests
{
    public static partial class CategoryTests
    {
        public class Profile : IDisposable
        {
            private Mockup mockup = new Mockup().SetupGlobal().SetupModel();

            public Profile()
            {

            }

            public void Dispose()
            {
                mockup.Dispose();
            }

            [Fact]
            void InputToEntity()
            {
                var mapper = mockup.Get<AppMapper>();
                var input = CategoryTests.CreateInput();
                var entity = mapper.MapCategory(input, new CategoryEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.CategoryId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = CategoryTests.CreateEntity();
                var view = mapper.MapCategory(entity, new Category());

                Assert.Equal(entity.CategoryId, view.CategoryId);
                AssertEqual(entity, view);
            }
        }
    }
}