using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Data;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Mapper.Types;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.AddDbContext<ApplicationDbContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


services.AddScoped(
        typeof(IBaseRepository<>),
        typeof(BaseRepository<>)
    );

services.AddScoped<IBaseRepository<Course>, CourseRepository>();

services.AddScoped<IObjectMapper<Block, BlockView>, BlockMapper>();
services.AddScoped<IObjectMapper<Professor, ProfessorView>, ProfessorMapper>();
services.AddScoped<IObjectMapper<Course, CourseView>,CourseMapper>();
services.AddScoped<IObjectMapper<User, UserView>, UserMapper>();
services.AddScoped<IObjectMapper<User, UserPreview>, UserPreviewMapper>();
services.AddScoped<ICareerProvider, CareerProviderRepository>();
services.AddScoped<IObjectMapper<Schedule, ScheduleView>, ScheduleMapper>();
services.AddScoped<IDataSourceDispatcher, MainDataSourceDispatcher>();
services.AddScoped<IDataSourceRepository, DataSourceRepository>();
services.AddScoped<ICourseManager, DefaultCourseManager>();

services.AddControllers();

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
