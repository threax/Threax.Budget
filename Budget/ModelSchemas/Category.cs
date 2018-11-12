﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Budget.ModelSchemas
{
    public class Category
    {
        [Required(ErrorMessage = "You must include a name.")]
        [MaxLength(1000, ErrorMessage = "The category name must be less than 1000 characters.")]
        public String Name { get; set; }
    }
}
