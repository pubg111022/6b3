using Microsoft.EntityFrameworkCore.Storage;
using pdf6b3.Databases;
using pdf6b3.Controllers;
using pdf6b3.Interfaces;
using pdf6b3.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

var configuration = builder.Configuration;
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOracle<StudentDbContext>(configuration.GetConnectionString("OracleConnection"));
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ISubject, SubjectService>();
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

//app.MapSubjectEndpoints();

app.Run();
