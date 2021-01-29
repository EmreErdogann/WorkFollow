using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkFollow.Business.Interfaces;
using WorkFollow.Business.Utilities;
using WorkFollow.Core.DTos;
using WorkFollow.Entities.Concrete;

namespace WorkFollow.UI.TagHelpers
{
    [HtmlTargetElement("GetTaskUserId")]
    public class TaskUserIdTagHelper : TagHelper
    {
        private readonly ITaskBusiness _taskBusiness;
        public TaskUserIdTagHelper(ITaskBusiness taskBusiness)
        {
            _taskBusiness = taskBusiness;
        }
        public int UserId { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Result<List<TaskDto>> gorevler = _taskBusiness.GetUserId(UserId);
            int tamamlananGorevSayisi = gorevler.Data.Where(I => I.Case).Count();
            int ustundeCalistigiGorevSayisi = gorevler.Data.Where(I => !I.Case).Count();

            string htmlString = $"<strong> Tamamladığı görev sayısı :</strong>{tamamlananGorevSayisi} <br> <strong> Üstünde çalıştığı görev sayısı : </strong>{ustundeCalistigiGorevSayisi}";

            output.Content.SetHtmlContent(htmlString);
            base.Process(context, output);
        }
    }
}
