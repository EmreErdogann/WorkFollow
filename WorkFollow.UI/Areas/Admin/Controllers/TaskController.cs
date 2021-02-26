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
using WorkFollow.Core.PagingListModels;

namespace WorkFollow.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class TaskController : Controller
    {
        private readonly ITaskBusiness _taskBusiness;
        private readonly IUrgencyBusiness _urgencyBusiness;
        private readonly IToastNotification _toastNotification;
        public TaskController(ITaskBusiness taskBusiness, IUrgencyBusiness urgencyBusiness, IToastNotification toastNotification)
        {
            _taskBusiness = taskBusiness;
            _urgencyBusiness = urgencyBusiness;
            _toastNotification = toastNotification;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            var data = _taskBusiness.GetAllDeleted();
            if (data.IsSuccess)
            {
                var model = PaginatedList<TaskDto>.CreateAsync(data.Data, pageNumber, 6);
                //var result = data.Data;
                return View(model);
            }

            return View(new List<TaskDto>());
        }

        [HttpGet]
        public IActionResult Create()
        {

            var result = _urgencyBusiness.GetAll();
            ViewBag.Tası = result.Data.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Create(TaskDto model)
        {

            if (ModelState.IsValid)
            {
                var data = _taskBusiness.Create(model);
                if (data.IsSuccess)
                {
                    _toastNotification.AddSuccessToastMessage(data.Message, new ToastrOptions
                    {
                        Title = "Başarılı İşlem"
                    });
                    return RedirectToAction("Index");
                }
                _toastNotification.AddErrorToastMessage("Gerekli Alanları Kontrol Edin");
                return RedirectToAction("Create");
            }
            else
            {
                var result = _urgencyBusiness.GetAll();
                ViewBag.Tası = result.Data.ToList();
                return View(model);
            }


        }

        [Route("urgency-details/{id}", Name = "urgencyDetailsRoute")]
        public ViewResult Get(int id)
        {
            var result = _urgencyBusiness.GetAll();
            ViewBag.Tası = result.Data.ToList();

            if (id < 0)
                return View();

            var data = _taskBusiness.GetById(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }

        [HttpPost]
        public IActionResult Update(TaskDto model)
        {
            if (ModelState.IsValid)
            {
                var data = _taskBusiness.Update(model);
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
                return View(model);
        }

        [HttpPost]
        public JsonResult Delete(int taskId)
        {
            if (taskId < 0)
                return Json("Index");
            var result = _taskBusiness.Delete(taskId);
            var ajaxResult = JsonSerializer.Serialize(result);
            return Json(ajaxResult);
        }
    }
}
