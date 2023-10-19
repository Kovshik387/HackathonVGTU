using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.DAL.Entities;

namespace HackathonVGTU.API.Commons.AutoMapper
{
    public class EntitiesMapping : Profile
    {
        public EntitiesMapping() : base() 
        {
            this.CreateMap<TeacherDto, TeacherEntity>().ReverseMap();
            this.CreateMap<ScheduleDto, ScheduleEntity>().ReverseMap();
            this.CreateMap<LessonDto, LessonEntity>().ReverseMap();
        } 
    }
}
