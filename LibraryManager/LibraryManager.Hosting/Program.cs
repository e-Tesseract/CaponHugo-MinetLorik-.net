using BusinessObjects.Entity;
using System.IO;
using DataAccessLayer.Contexts;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add custom services
//string path = Path.GetFullPath($"{Directory.GetCurrentDirectory()}\\library.db");
string path = "C:\\Users\\capon\\Desktop\\iut\\BUT3\\.net\\CaponHugo-MinetLorik-.net\\LibraryManager\\DataAccessLayer\\library.db";
builder.Services.AddScoped<IGenericRepository<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IGenericRepository<Author>, GenericRepository<Author>>();
builder.Services.AddScoped<IGenericRepository<Library>, GenericRepository<Library>>();
builder.Services.AddScoped<ICatalogManager, CatalogManager>();
builder.Services.AddDbContext<LibraryContext>(options =>
  options.UseSqlite($"Data Source={path};")
         .EnableSensitiveDataLogging(false)
         .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning)))
         );


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
