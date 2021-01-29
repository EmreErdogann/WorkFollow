using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WorkFollow.Business.Interfaces;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.UI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles = "Member")]
    public class HomeController : Controller
    {
        private readonly IReportBusiness _reportBusiness;
        private readonly UserManager<User> _userManager;
        private readonly ITaskBusiness _taskBusiness;

        public HomeController(IReportBusiness reportBusiness, UserManager<User> userManager, ITaskBusiness taskBusiness)
        {
            _userManager = userManager;
            _reportBusiness = reportBusiness;
            _taskBusiness = taskBusiness;
        }
        public async Task< IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //var user = Convert.ToInt32(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            ViewBag.ReportNumber = _reportBusiness.GetReportNumberUserId(user.Id);
            ViewBag.TamamlananGorev = _taskBusiness.GetTaskUser(user.Id);
            return View();
        }
    }
}
