using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IToastNotification _toastNotification;

        public ProfileController(UserManager<User> userManager, SignInManager<User> signInManager, IToastNotification toastNotification)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var userDto = new UserDto
            {
                Email = user.Email,
                Name = user.Name,
                SurName = user.SurName,
                Picture = user.Picture,
                Id = user.Id
            };
            return View(userDto);
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserDto model, IFormFile resim)
        {

            if (ModelState.IsValid)
            {
                var updateUser = _userManager.Users.FirstOrDefault(I => I.Id == model.Id);
                if (resim != null)
                {
                    string uzanti = Path.GetExtension(resim.FileName);
                    string resimAd = Guid.NewGuid() + uzanti;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + resimAd);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await resim.CopyToAsync(stream);
                    }

                    updateUser.Picture = resimAd;
                }

                updateUser.Name = model.Name;
                updateUser.SurName = model.SurName;
                updateUser.Email = model.Email;

                var result = await _userManager.UpdateAsync(updateUser);
                if (result.Succeeded)
                {
                    _toastNotification.AddSuccessToastMessage("Bilgileriniz Başarı İle Güncellenmiştir", new ToastrOptions
                    {
                        Title = "Başarılı İşlem"
                    });
                    return RedirectToAction("Index");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Home", new { Area = "" });
        }
    }
}
