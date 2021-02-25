using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WorkFollow.Business.Interfaces;
using WorkFollow.Core.DTos;

namespace WorkFollow.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class UrgencyController : Controller
    {
        private readonly IUrgencyBusiness _urgencyBusiness;
        private readonly IToastNotification _toastNotification;
        public UrgencyController(IUrgencyBusiness urgencyBusiness, IToastNotification toastNotification)
        {
            _urgencyBusiness = urgencyBusiness;
            _toastNotification = toastNotification;
        }
        public IActionResult Index()
        {
            var data = _urgencyBusiness.GetAllDeleted();
            if (data.IsSuccess)
            {
                var result = data.Data;
                return View(result);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UrgencyDto model)
        {
            if (ModelState.IsValid)
            {
                var data = _urgencyBusiness.Create(model);
                if (data.IsSuccess)
                {
                    _toastNotification.AddSuccessToastMessage(data.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem"
                    });
                    return RedirectToAction("Index");
                }


                return View();
            }
            else
                _toastNotification.AddErrorToastMessage("Gerekli Alanları Kontrol Edin");
            return View(model);
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            if (id < 0)
                return View();

            var data = _urgencyBusiness.GetById(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }

        public IActionResult Update(UrgencyDto model)
        {
            if (ModelState.IsValid)
            {
                var data = _urgencyBusiness.Update(model);
                if (data.IsSuccess)
                {
                    _toastNotification.AddSuccessToastMessage(data.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem"
                    });
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                _toastNotification.AddErrorToastMessage("Gerekli Alanları Kontrol Edin");
            return View(model);
        }

        public IActionResult Delete(int urgencyId)
        {
            if (urgencyId < 0)
                return View();
            var result = _urgencyBusiness.Delete(urgencyId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
    }
}
