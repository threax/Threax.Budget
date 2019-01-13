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
    public static partial class CategoryTests
    {
        public static CategoryInput CreateInput(String seed = "", String Name = default(String), decimal Total = default(decimal))
        {
            return new CategoryInput()
            {
                Name = Name != null ? Name : $"Name {seed}",
                Total = Total,
            };
        }


        public static CategoryEntity CreateEntity(String seed = "", Guid? CategoryId = default(Guid?), String Name = default(String), decimal Total = default(decimal))
        {
            return new CategoryEntity()
            {
                CategoryId = CategoryId.HasValue ? CategoryId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                Total = Total,
            };
        }


        public static Category CreateView(String seed = "", Guid? CategoryId = default(Guid?), String Name = default(String), decimal Total = default(decimal))
        {
            return new Category()
            {
                CategoryId = CategoryId.HasValue ? CategoryId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
                Total = Total,
            };
        }


        public static void AssertEqual(ICategory expected, ICategory actual)
        {
           Assert.Equal(expected.Name, actual.Name);
           Assert.Equal(expected.Total, actual.Total);
        }

    }
}