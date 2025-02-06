using Microsoft.EntityFrameworkCore;
using ucn_user_review_backend_v3.Base;
using ucn_user_review_backend_v3.Data;
using ucn_user_review_backend_v3.Mapper;
using ucn_user_review_backend_v3.Model;
using ucn_user_review_backend_v3.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => {
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});


builder.Services.AddScoped(
        typeof(IBaseRepository<>),
        typeof(BaseRepository<>)
    );

builder.Services.AddScoped<IBaseRepository<Course>, CourseRepository>();

builder.Services.AddScoped<IObjectMapper<Block, BlockView>, BlockMapper>();
builder.Services.AddScoped<IObjectMapper<Professor, ProfessorView>, ProfessorMapper>();
builder.Services.AddScoped<IObjectMapper<Course, CourseView>,CourseMapper>();
builder.Services.AddScoped<IObjectMapper<User, UserView>, UserMapper>();
builder.Services.AddScoped<ICareerProvider, CareerProviderRepository>();
builder.Services.AddScoped<IObjectMapper<Schedule, ScheduleView>, ScheduleMapper>();
builder.Services.AddScoped<IDataSourceDispatcher, MainDataSourceDispatcher>();
builder.Services.AddScoped<IDataSourceRepository, DataSourceRepository>();
builder.Services.AddScoped<ICourseManager, DefaultCourseManager>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
