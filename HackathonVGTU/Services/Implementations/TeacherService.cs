using AutoMapper;
using HackathonVGTU.API.Services.DataTransfer;
using HackathonVGTU.API.Services.Interfaces;
using HackathonVGTU.DAL;
using HackathonVGTU.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
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
                await dbcontext.AddAsync(this.mapper.Map<TeacherEntity>(teacher));
                await dbcontext.SaveChangesAsync();
            }
        }

        public async Task<List<TeacherDto>> GetAllTeachers(string? name)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var GetFullname = Expression<>.Lambda((TeacherEntity t) => string.Concat(t.Surname, " ", t.Name, " ", t.Patronymic));
                var resultList = name switch
                {
                    null => await dbcontext.Teachers.ToListAsync(),
                    _ => await dbcontext.Teachers
                        .Where(t => EF.Functions.Like(GetFullname(t)?., $"%{name ?? string.Empty}%"))
                        .ToListAsync(),
                };
                return this.mapper.Map<List<TeacherDto>>(resultList);
            }
        }

        public async Task<TeacherDto?> GetTeacherByCode(int code)
        {
            using (var dbcontext = await this.factory.CreateDbContextAsync())
            {
                var result = dbcontext.Teachers
                    .Where(item => item.Code == code).Include(item => item.Lessons)
                    .ThenInclude(item => item.Schedule).FirstOrDefaultAsync();
                return this.mapper.Map<TeacherDto>(result);
            }
        }
    }
}
