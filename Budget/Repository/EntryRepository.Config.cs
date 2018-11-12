using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Threax.ReflectedServices;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Budget.Repository;

namespace Budget.Repository.Config
{
    public partial class EntryRepositoryConfig : IServiceSetup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            OnConfigureServices(services);

            services.TryAddScoped<IEntryRepository, EntryRepository>();
        }

        partial void OnConfigureServices(IServiceCollection services);
    }
}