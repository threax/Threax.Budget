using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Budget.Controllers
{
    public partial class HomeController
    {
        public Task<IActionResult> Categories()
        {
            return CacheUiView();
        }
    }
}