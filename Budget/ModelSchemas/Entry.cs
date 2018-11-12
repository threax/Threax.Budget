using Budget.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Threax.AspNetCore.Models;

namespace Budget.ModelSchemas
{
    public class Entry
    {
        public String Description { get; set; }

        public decimal Total { get; set; }

        [DefineValueProvider(typeof(CategoryValueProvider))]
        public Guid CategoryId { get; set; }
    }
}
