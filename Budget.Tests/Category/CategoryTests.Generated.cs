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
        public static CategoryInput CreateInput(String seed = "", String Name = default(String))
        {
            return new CategoryInput()
            {
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static CategoryEntity CreateEntity(String seed = "", Guid? CategoryId = default(Guid?), String Name = default(String))
        {
            return new CategoryEntity()
            {
                CategoryId = CategoryId.HasValue ? CategoryId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static Category CreateView(String seed = "", Guid? CategoryId = default(Guid?), String Name = default(String))
        {
            return new Category()
            {
                CategoryId = CategoryId.HasValue ? CategoryId.Value : Guid.NewGuid(),
                Name = Name != null ? Name : $"Name {seed}",
            };
        }


        public static void AssertEqual(ICategory expected, ICategory actual)
        {
           Assert.Equal(expected.Name, actual.Name);
        }

    }
}