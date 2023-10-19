using HackathonVGTU.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HackathonVGTU.API.Controllers
{
    [Controller, Route("schedule")]
    public partial class ScheduleController : Controller
    {
        public IScheduleService ScheduleService { get; private set; } = default!;
        public ILogger<TeacherController> Logger { get; private set; } = default!;

        public ScheduleController(IScheduleService scheduleService, ILogger<TeacherController> logger) : base()
        {
            this.ScheduleService = scheduleService;
            this.Logger = logger;
        }

        [HttpGet, Route("GetGroupsList")]
        public async Task<JsonResult> GetGroupsList()
        {
            return this.Json(await this.ScheduleService.GetGroupsList());
        }

        [HttpGet, Route("GetGroupsListByFaculty")]
        public async Task<JsonResult> GetGroupsListByFaculty(string faculty)
        {
            return this.Json(await this.ScheduleService.GetGroupsListByFaculty(faculty));
        }

        [HttpGet, Route("GetGroupsListByName")]
        public async Task<JsonResult> GetGroupsListByName(string group)
        {
            return this.Json(await this.ScheduleService.GetGroupsListByName(group));
        }

        [HttpGet, Route("GetSchedules")]
        public async Task<JsonResult> GetSchedules(string group)
        {
            return this.Json(await this.ScheduleService.GetSchedules(group));
        }

        [HttpGet, Route("GetAllFaculties")]
        public async Task<JsonResult> GetAllFaculties()
        {
            return this.Json(await this.ScheduleService.GetAllFaculties());
        }
    }
}
