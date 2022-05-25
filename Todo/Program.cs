using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;
using Todo.Business.Abstract;
using Todo.Business.Concrete;
using Todo.Core;
using Todo.DataAccess;
using Todo.DataAccess.Abstract;
using Todo.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ITokenHelper, JwtHelper>();
builder.Services.AddScoped<DatabaseContext>();
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Todo")));
builder.Services.AddScoped<DatabaseContext>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

BuilderAddSingletonOperations(builder);

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["JWT:Issuer"],
            ValidAudience = builder.Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecurityKey"]))
        };
    });
builder.Services.AddCors(option => option.AddDefaultPolicy(v => v.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()));


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

app.UseAuthorization();

app.MapControllers();

AddMigrationsAutomatically(app);

app.Run();





static void AddMigrationsAutomatically(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var db = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
        try { db.Database.Migrate(); }
        catch (Exception e) { Console.WriteLine(e.Message); }
    }
}

static void BuilderAddSingletonOperations(WebApplicationBuilder builder)
{
    builder.Services.AddSingleton<IDailyTodoService, DailyTodoManager>();
    builder.Services.AddSingleton<IDailyTodoDal, DailyTodoDal>();

    builder.Services.AddSingleton<IWeeklyTodoService, WeeklyTodoManager>();
    builder.Services.AddSingleton<IWeeklyTodoDal, WeeklyTodoDal>();

    builder.Services.AddSingleton<IMonthlyTodoService, MonthlyTodoManager>();
    builder.Services.AddSingleton<IMonthlyTodoDal, MonthlyTodoDal>();   
    
    builder.Services.AddSingleton<IAuthenticationService, AuthenticationManager>();
    builder.Services.AddSingleton<ITokenHelper, JwtHelper>();

    builder.Services.AddSingleton<IUserService, UserManager>();
    builder.Services.AddSingleton<IUserDal, UserDal>();

    builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
}