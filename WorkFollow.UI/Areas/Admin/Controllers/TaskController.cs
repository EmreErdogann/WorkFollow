using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public TaskController(ITaskBusiness taskBusiness, IUrgencyBusiness urgencyBusiness)
        {
            _taskBusiness = taskBusiness;
            _urgencyBusiness = urgencyBusiness;
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
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Create");
            }
            else
            {
                var result = _urgencyBusiness.GetAll();
                ViewBag.Tası = result.Data.ToList();
                return View(model);
            }


        }

        [HttpGet]
        public IActionResult Get(int id)
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
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                return View(model);
        }

      
        public IActionResult Delete(int taskId)
        {
            if (taskId < 0)
                return View();

            _taskBusiness.Delete(taskId);
            return Json(null);
        }
    }
}
