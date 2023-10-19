using AngleSharp;
using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using HackathonVGTU.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HackathonVGTU.API.Controllers
{
    [Controller, Route("/")]
    public class ResetController : Controller
    {
        public ITeacherService TeacherService { get; set; } = default!;
        public IMapper Mapper { get; set; } = default!;
        public IScheduleService ScheduleService { get; set; } = default!;

        private const string BaseUrl = "https://cchgeu.ru";

        public ResetController(IScheduleService scheduleService, ITeacherService teacherService) : base()
        {
            this.ScheduleService = scheduleService;
            this.TeacherService = teacherService;
        }

        [HttpGet, Route("/reset")]
        public async Task AllReset()
        {
            var config = Configuration.Default.WithDefaultLoader();
            using var context = BrowsingContext.New(config);

            var url = "https://cchgeu.ru/studentu/nayti-kontakty-prepodavatelya/";
            using var doc = await context.OpenAsync(url);

            var pars = doc.QuerySelectorAll(@"p[class=""name""]");
            var teacher_data = new List<TeacherDto>();

            foreach (var par in pars)
            {
                string pattern = @"employees/|/|university";
                var code = Regex.Replace(par!.LastElementChild!.GetAttribute("href")!, pattern, "");


                var doc_teacher = await context.OpenAsync(BaseUrl + par.LastElementChild!.GetAttribute("href"));
                var temp = doc_teacher.Title!.Replace("\t", "").Split(); // Имя фамилия

                var details = doc_teacher.QuerySelectorAll(@"div[class=""employee-detail-info""]")[0].TextContent;

                var llist_details = details.Replace("\n", "").Split("\t");
                var list = llist_details.Where(i => i != "" && i != " ").ToList();
                list.Remove("E-mail:");
                list.Remove("Должность: ");

                var list_items = list.Where(i => i != "  ").ToList();
                var Image = doc_teacher.QuerySelector(@"div[class=""employee-detail-photo""]")!.Attributes[1];

                var image_sub_result = Image!.Value.Split(" ");
                var image_result = image_sub_result[1].Replace("url(", "");
                var image = image_result.Remove(image_result.Length - 1).Remove(image_result.Length - 2);

                if (list_items.Count <= 4)
                {
                    teacher_data.Add(new TeacherDto()
                    {
                        Education = list_items[0],
                        Post = list_items[1],
                        Email = list_items[2],
                        Department = list_items[list_items.Count - 1],
                        Code = int.Parse(code),
                        Surname = temp[0],
                        Name = temp[1],
                        Patronymic = temp[2],
                        Image = BaseUrl + image
                    });
                }
                else
                {
                    teacher_data.Add(new TeacherDto()
                    {
                        Education = list_items[0],
                        Post = list_items[1],
                        Email = list_items[3],
                        Phone = list_items[2].Replace("Телеофон: ", ""),
                        Department = list_items[list_items.Count - 1],
                        Code = int.Parse(code),
                        Surname = temp[0],
                        Name = temp[1],
                        Patronymic = temp[2],
                        Image = BaseUrl + image
                    });
                }

            }
            foreach(var item in teacher_data) await this.TeacherService.AddTeacher(item);
        }

    }
}
