﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Threax.AspNetCore.UserBuilder.Entities;

namespace Budget.Controllers
{
    [Authorize(AuthenticationSchemes = AuthCoreSchemes.Cookies)]
    public class AdminController : Controller
    {
        [Authorize(Roles = AuthorizationAdminRoles.EditRoles)]
        public IActionResult Users()
        {
            return View();
        }
    }
}
