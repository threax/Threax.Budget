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
    public static partial class EntryTests
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
                var input = EntryTests.CreateInput();
                var entity = mapper.MapEntry(input, new EntryEntity());

                //Make sure the id does not copy over
                Assert.Equal(default(Guid), entity.EntryId);
                AssertEqual(input, entity);
            }

            [Fact]
            void EntityToView()
            {
                var mapper = mockup.Get<AppMapper>();
                var entity = EntryTests.CreateEntity();
                var view = mapper.MapEntry(entity, new Entry());

                Assert.Equal(entity.EntryId, view.EntryId);
                AssertEqual(entity, view);
            }
        }
    }
}