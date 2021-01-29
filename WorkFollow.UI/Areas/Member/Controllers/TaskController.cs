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
    [Authorize(Roles = "Member")]
    [Area("Member")]
    public class TaskController : Controller
    {
        private readonly ITaskBusiness _taskBusiness;
        public TaskController(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }
        public IActionResult Index(int pageNumber = 1)
        {
            var userId = Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            var data = _taskBusiness.UserReportUrgencyGetAllCompleted(userId);
            if (data.IsSuccess)
            {
                var model = PaginatedList<TaskDto>.CreateAsync(data.Data, pageNumber, 3);
                //var result = data.Data;
                return View(model);
            }
            return View();
        }
    }
}
