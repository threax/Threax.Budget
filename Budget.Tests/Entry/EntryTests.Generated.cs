using AutoMapper;
using Budget.Database;
using Budget.InputModels;
using Budget.Repository;
using Budget.Models;
using Budget.ViewModels;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;

namespace Budget.Tests
{
    public static partial class EntryTests
    {
        public static EntryInput CreateInput(String seed = "", String Description = default(String), decimal Total = default(decimal))
        {
            return new EntryInput()
            {
                Description = Description != null ? Description : $"Description {seed}",
                Total = Total,
            };
        }


        public static EntryEntity CreateEntity(String seed = "", Guid? EntryId = default(Guid?), String Description = default(String), decimal Total = default(decimal))
        {
            return new EntryEntity()
            {
                EntryId = EntryId.HasValue ? EntryId.Value : Guid.NewGuid(),
                Description = Description != null ? Description : $"Description {seed}",
                Total = Total,
            };
        }


        public static Entry CreateView(String seed = "", Guid? EntryId = default(Guid?), String Description = default(String), decimal Total = default(decimal))
        {
            return new Entry()
            {
                EntryId = EntryId.HasValue ? EntryId.Value : Guid.NewGuid(),
                Description = Description != null ? Description : $"Description {seed}",
                Total = Total,
            };
        }


        public static void AssertEqual(IEntry expected, IEntry actual)
        {
           Assert.Equal(expected.Description, actual.Description);
           Assert.Equal(expected.Total, actual.Total);
        }

    }
}