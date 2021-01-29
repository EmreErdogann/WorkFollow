using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFollow.Business.Interfaces;
using WorkFollow.Core.DTos;
using WorkFollow.Core.PagingListModels;
using WorkFollow.Entities.Concrete;
using WorkFollow.UI.Areas.Admin.Models;


namespace WorkFollow.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class WorkOrderController : Controller
    {
        private readonly ITaskBusiness _taskBusiness;
        private readonly UserManager<User> _userManager;
        private readonly IUserBusiness _userBusiness;


        public WorkOrderController(ITaskBusiness taskBusiness, UserManager<User> userManager, IUserBusiness userBusiness)
        {
            _taskBusiness = taskBusiness;
            _userManager = userManager;
            _userBusiness = userBusiness;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            var data = _taskBusiness.UserReportUrgencyGetAll();
            if (data.IsSuccess)
            {
                var model = PaginatedList<TaskDto>.CreateAsync(data.Data, pageNumber, 6);
                //var result = data.Data;
                return View(model);
            }
            return View();

        }
        public IActionResult AssignPersonnel(int id )
        {

            if (id < 0)
                return View();

            ViewBag.Verı = _userBusiness.GetAdmın().Data;

            var result = _taskBusiness.GetUrcenyId(id);
            return View(result.Data);

           
        }

        public IActionResult PersonnelAta(AssignStaffViewModel model)
        {

            var user = _userManager.Users.FirstOrDefault(ı => ı.Id == model.StaffId);
            var duty = _taskBusiness.GetUrcenyId(model.DutyId).Data;
            if (user != null)
                duty.User = user;
            return View(duty);
        }

        [HttpPost]
        public IActionResult PersonnelCreate(AssignStaffViewModel model)
        {
            var update = _taskBusiness.GetById(model.DutyId);
            update.Data.UserId = model.StaffId;
            var data = _taskBusiness.Update(update.Data);
            if (data.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Detail(int id)
        {
            var result = _taskBusiness.GetReportId(id).Data;
            return View(result);
        }
    }
}
