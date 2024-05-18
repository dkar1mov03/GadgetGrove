using Serilog;
using Newtonsoft.Json;
using GadgetGrove.Api.Models;
using GadgetGrove.Shared.Helpers;
using GadgetGrove.Api.Extensions;
using GadgetGrove.Api.Middlewares;
using GadgetGrove.Data.DbContexts;
using GadgetGrove.Service.Mappers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

var builder = WebApplication.CreateBuilder(args);
/// Fix the Cycle
builder.Services.AddControllers()
     .AddNewtonsoftJson(options =>
     {
         options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
     });

builder.Services.AddDbContext<GadgetGroveDbContext>(option
            => option.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Administration", p => p.RequireRole("Admin", "SuperAdmin"));

});
builder.Services.AddJwtService(builder.Configuration);
// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddCustomServices();
builder.Services.AddAutoMapper(typeof(MapperProfile));

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


//Logger
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new RouteTokenTransformerConvention(
                                    new ConfigurationApiUrlName()));
});

var app = builder.Build();
EnvironmentContextHelper.WebRootPath = Path.GetFullPath("wwwroot");


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlerMiddleWare>();
app.UseAuthorization();
app.UseStaticFiles();


app.UseCors("AllowAll");

app.UseAuthorization();
app.MapControllers();

app.Run();