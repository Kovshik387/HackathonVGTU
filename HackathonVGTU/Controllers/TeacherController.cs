using HackathonVGTU.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace HackathonVGTU.API.Controllers
{
    [Controller, Route("teacher")]
    public class TeacherController : Controller
    {
        public ITeacherService TeacherService { get; private set; } = default!;
        public ILogger<TeacherController> Logger { get; private set; } = default!;

        public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger) : base()
        {
            this.TeacherService = teacherService;
            this.Logger = logger;
        }

        [HttpGet, Route("GetAllTeacher")]
        public async Task<JsonResult> GetAllTeacher(string name)
        {
            return this.Json(await this.TeacherService.GetAllTeachers(name));
        }

        [HttpGet, Route("GetTeacherByCode")]
        public async Task<JsonResult> GetTeacherByCode(int code)
        {
            return this.Json(await this.TeacherService.GetTeacherByCode(code));
        }
    }
}
