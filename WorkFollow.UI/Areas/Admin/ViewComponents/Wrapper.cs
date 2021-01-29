using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.UI.Areas.Admin.ViewComponents
{
    public class Wrapper : ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public Wrapper(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public IViewComponentResult Invoke()
        {
            var user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var userDto = new UserDto
            {
                Email = user.Email,
                Name = User.Identity.Name,
                SurName = user.SurName,
                Picture = user.Picture,
                Id = user.Id
            };
            return View(userDto);
        }
    }
}
