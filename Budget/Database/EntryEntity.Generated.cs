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

namespace Budget.Database 
{
    public partial class EntryEntity : IEntry, IEntryId, ICreatedModified
    {
        [Key]
        public Guid EntryId { get; set; }

        public String Description { get; set; }

        public decimal Total { get; set; }

        public Guid CategoryId { get; set; }

        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

    }
}
