using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using HackathonVGTU.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HackathonVGTU.API.Services.Implementations
{
    public partial class TeacherService : ITeacherService
    {
        private readonly IDbContextFactory<VgtuFinderDbContext> factory = default!;

        private readonly IMapper mapper = default!;
        public TeacherService(IDbContextFactory<VgtuFinderDbContext> factory, IMapper mapper) : base()
        {
            this.factory = factory;
            this.mapper = mapper;
        }

        public async Task AddTeacher(TeacherDto teacher)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                await dbcontext.AddAsync(mapper.Map<TeacherEntity>(teacher));
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<TeacherDto>> GetAllTeachers(string field)
        {
            var regex = new Regex(field);
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var resultList = await dbcontext.Teachers
                    .Where(item => regex.IsMatch($"{item.Surname} {item.Name} {item.Patronymic}")).ToListAsync();

                return mapper.Map<List<TeacherDto>>(resultList);
            }
        }

        public async Task<TeacherDto?> GetTeacherByCode(int code)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var result = dbcontext.Teachers.FirstOrDefaultAsync(item => item.Code == code);
                return mapper.Map<TeacherDto>(result);
            }
        }
    }
}
