using Microsoft.AspNetCore.Mvc;
using AngleSharp;
using AngleSharp.Html.Parser;
using Microsoft.Extensions.Logging;
using AngleSharp.Html.Dom;
using HackathonVGTU.DAL.Entities;

namespace HackathonVGTU.API.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ILogger<TeacherController> _logger;
        public TeacherController(ILogger<TeacherController> logger) => _logger = logger;

        [Route("/GetTeacher")]
        [HttpGet]
        public async Task<IList<TeacherEntity>> TeacherBy()
        {
            var base_url = "https://cchgeu.ru";

            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);

            var url = "https://cchgeu.ru/studentu/nayti-kontakty-prepodavatelya/";

            using var doc = await context.OpenAsync(url);

            var pars = doc.QuerySelectorAll(@"p[class=""name""]");

            List<TeacherEntity> teacher_data = new();

            foreach ( var par in pars)
            {
                var doc_teacher = await context.OpenAsync(base_url + par.LastElementChild!.GetAttribute("href"));

                var temp = doc.Title.Replace("\t","").Split(); // Имя фамилия

                
                
                _logger.LogCritical(temp);



                //teacher_data.Add(new TeacherEntity()
                //{
                //    Department
                //});
            }
            
            //foreach (var url_item in url_teacher ) 
            //{
            //    var doc_teacher = await context.OpenAsync(url_item);

            //    var pars_teacher = doc_teacher.QuerySelector(@"div[class=""midle""]");

            //}


            //var url_teacher = 

            //List<String> new_pars = new();

            //foreach (var item in pars)
            //{
            //    _logger.LogWarning(item.TextContent.ToString());
            //    var sub_item = item.TextContent.ToString().Replace("\t", "").Replace("\n", "");
            //    new_pars.Add(sub_item);
            //    _logger.LogInformation(sub_item.ToString());
            //}

            return teacher_data;
        }

    }
}
