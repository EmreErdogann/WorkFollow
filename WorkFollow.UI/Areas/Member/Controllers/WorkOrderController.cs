using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkFollow.Business.Interfaces;
using WorkFollow.Core.DTos;
using WorkFollow.Core.PagingListModels;

namespace WorkFollow.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class WorkOrderController : Controller
    {
        private readonly ITaskBusiness _taskBusiness;
        private readonly IReportBusiness _reportBusiness;


        public WorkOrderController(ITaskBusiness taskBusiness, IReportBusiness reportBusiness)
        {
            _taskBusiness = taskBusiness;
            _reportBusiness = reportBusiness;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            var userId = Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            var data = _taskBusiness.UserReportUrgencyGetAll(userId);
            if (data.IsSuccess)
            {
                var model = PaginatedList<TaskDto>.CreateAsync(data.Data, pageNumber, 3);
                //var result = data.Data;
                return View(model);
            }
            return View();
        }

        public IActionResult Create(int id)
        {
            if (id < 0)
                return View();
            var result = _taskBusiness.GetUrcenyId(id);
            return View(result.Data);

        }

        [HttpPost]
        public IActionResult Create(ReportDto model)
        {
            if (ModelState.IsValid)
            {
                model.Id = 0;
                _taskBusiness.GetUrcenyId(model.TaskId);
                var data = _reportBusiness.Create(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
            {
                return RedirectToAction("Deneme");
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id < 0)
                return View();
            var result = _reportBusiness.GetTaskId(id);

            return View(result.Data);
        }

        [HttpPost]
        public IActionResult Update(ReportDto model)
        {
            if (ModelState.IsValid)
            {

                var data = _reportBusiness.Update(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                return View(model);
        }

        public IActionResult CompleteTask(int id)
        {
            var task = _taskBusiness.GetById(id);
            task.Data.Case = true;
            _taskBusiness.Update(task.Data);
            return Json(null);
        }

      
    }
}
