using Formula1Api.Data;
using Formula1Api.Interfaces;
using Formula1Api.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<FormulaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FormulaConnection")));


builder.Services.AddCors(options => 



{
    options.AddPolicy("AllowLocalhost",
        builder =>
        {
            builder.WithOrigins("http://localhost:52594")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            builder.WithOrigins("http://localhost:4200")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            builder.WithOrigins("http://localhost:49917")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
            builder.WithOrigins("http://localhost:56553")
                   .AllowAnyHeader()
                   .AllowAnyMethod();
        });
});


// Add services to the container.
builder.Services.AddScoped<DriversInterFace, DriversService>();
builder.Services.AddScoped<TeamInterFace, TeamsService>();
builder.Services.AddScoped<AdminInterface, AdminService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseCors("AllowLocalhost");
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Photos")),
    RequestPath = "/Photos"
});


app.UseCors(options =>
  options.WithOrigins("http://localhost:7197")
    .AllowAnyMethod()
    .AllowAnyHeader());
builder.Services.AddCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
