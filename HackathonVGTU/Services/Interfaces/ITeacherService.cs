using HackathonVGTU.API.Services.DataTransfer;

namespace HackathonVGTU.API.Services.Interfaces
{
    public interface ITeacherService
    {
        public Task AddTeacher(TeacherDto teacher);
        public Task<List<TeacherDto>> GetAllTeachers(string field);

        public Task<TeacherDto?> GetTeacherByCode(int code);
    }
}
