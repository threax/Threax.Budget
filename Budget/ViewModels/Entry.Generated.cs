using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Halcyon.HAL.Attributes;
using Threax.AspNetCore.Halcyon.Ext;
using Threax.AspNetCore.Models;
using Threax.AspNetCore.Tracking;
using Budget.Models;
using Budget.Controllers.Api;
using Threax.AspNetCore.Halcyon.Ext.ValueProviders;

namespace Budget.ViewModels 
{
       public partial class Entry : IEntry, IEntryId, ICreatedModified
       {
        public Guid EntryId { get; set; }

        public String Description { get; set; }

        public decimal Total { get; set; }

        [ValueProvider(typeof(Budget.Services.CategoryValueProvider))]
        public Guid CategoryId { get; set; }

        [UiOrder(0, 2147483646)]
        [DateUiType]
        public DateTime Created { get; set; }

        [UiOrder(0, 2147483647)]
        public DateTime Modified { get; set; }

    }
}
