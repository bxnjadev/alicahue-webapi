using DotNetEnv;
using Microsoft.EntityFrameworkCore;
using Npgsql;
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

//Env.Load();

//var connectionString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION");

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

Console.WriteLine(connectionString);

services.AddDbContext<ApplicationDbContext>(options => {
    options.UseNpgsql(connectionString);
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

builder.Services.AddCors(options =>
{
    options.AddPolicy("Frontend", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<ApplicationDbContext>();

    var connection = (NpgsqlConnection)db.Database.GetDbConnection();

    try
    {

      
        await using var command = connection.CreateCommand();

        command.CommandText = """
                              SELECT
                                  datname,
                                  pg_get_userbyid(datdba) AS owner,
                                  datallowconn
                              FROM pg_database
                              WHERE NOT datistemplate
                              ORDER BY datname;
                              """;

        await using var reader = await command.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            Console.WriteLine(
                $"Database: {reader.GetString(0)}, " +
                $"Owner: {reader.GetString(1)}, " +
                $"Allow connection: {reader.GetBoolean(2)}"
            );
        }
        
        
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error de conexión: {ex.Message}");
    }
    finally
    {
        await connection.CloseAsync();
    }
    
    
    
}

app.UseCors("Frontend");

var port = Environment.GetEnvironmentVariable("PORT") ?? "80";

builder.WebHost.UseUrls(
    $"http://0.0.0.0:{port}"
);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () =>
{
    return Results.Ok(new
    {
        message = "Backend funcionando"
    });
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
