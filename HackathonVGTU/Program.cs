using HackathonVGTU.API.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddBllServices(builder.Configuration);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var factory = app.Services.GetService<IDbContextFactory<HackathonVGTU.DAL.VgtuFinderDbContext>>();

using (var dbcontext = await factory!.CreateDbContextAsync())
{
    await dbcontext.Database.MigrateAsync();
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
// app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
