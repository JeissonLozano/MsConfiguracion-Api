using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MsConfiguracion.Infrastructure.Context;
using MsConfiguracion.Infrastructure.Extensions;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(Assembly.Load("MsConfiguracion.Application"), typeof(Program).Assembly);
builder.Services.AddAutoMapper(Assembly.Load("MsConfiguracion.Application"));

builder.Services.AddDbContext<PersistenceContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("database"), sqlopts =>
    {
        sqlopts.MigrationsHistoryTable("_MigrationHistory", config["SchemaName"]);
    });
});

builder.Services.AddLogging(logginBuilder => logginBuilder.AddSerilog(dispose: true));

builder.Services.AddPersistence().AddDomainServices();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo{ Title = "SISGOP-PC Ms-Configuracion Api", Version = "v1" });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
