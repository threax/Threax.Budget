using AutoMapper;
using Budget.Database;
using Budget.InputModels;
using Budget.Repository;
using Budget.Models;
using Budget.ViewModels;
using Budget.Mappers;
using System;
using Threax.AspNetCore.Tests;
using Xunit;
using System.Collections.Generic;

namespace Budget.Tests
{
    public static partial class EntryTests
    {
        private static Mockup SetupModel(this Mockup mockup)
        {
            mockup.Add<IEntryRepository>(m => new EntryRepository(m.Get<AppDbContext>(), m.Get<AppMapper>()));

            return mockup;
        }
    }
}