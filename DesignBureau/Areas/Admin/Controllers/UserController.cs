﻿using DesignBureau.Core.Contracts;
using DesignBureau.Core.Models.Admin.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using static DesignBureau.Core.Constants.AdminConstants;

namespace DesignBureau.Areas.Admin.Controllers
{
    public class UserController : AdminBaseController
    {
        private readonly IUserService userService;
        private readonly IMemoryCache memoryCache;

        public UserController(IUserService userService, IMemoryCache memoryCache)
        {
            this.userService = userService;
            this.memoryCache = memoryCache;
        }

        public async Task<IActionResult> All()
        {
            var model = memoryCache.Get<IEnumerable<UserAllServiceModel>>(UsersCacheKey);

            if (model == null || model.Any() == false)
            {
                model = await userService.AllAsync();

                var cacheOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(5));

                memoryCache.Set(UsersCacheKey, model, cacheOptions);
            }

            return View(model);
        }
    }
}
